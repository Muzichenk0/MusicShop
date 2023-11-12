using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.Contracts.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicShop.AppData.Contexts.User.Services
{
    /// <summary>
    /// Конкретный ссылочный тип, реализующий интерфейс для сущности - сервис пользователя.
    /// </summary>
    public sealed class UserService : IUserService
    {
        /// <summary>
        /// Конкретный репозиторий, связанный с моделью - пользователь.
        /// </summary>
        private readonly IUserRepository _repository;
        /// <summary>
        /// Доступ к основной информации о входящем запросе, для обработки.
        /// </summary>
        private readonly IHttpContextAccessor _accessor;
        /// <summary>
        /// Конфигурация сборки, проекта.
        /// </summary>
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository repository, IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _repository = repository;
            _accessor = accessor;
            _configuration = configuration;
        }
        ///<inheritdoc/>
        public async Task<Guid> AddUserAsync(CreateUserRequest createUserDto, CancellationToken cancelToken = default)
            => await _repository.AddAsync(createUserDto, cancelToken);
        ///<inheritdoc/>
        public async Task DeleteUserAsync(DeleteUserRequest deleteUserDto, CancellationToken cancelToken = default)
            => await _repository.DeleteAsync(deleteUserDto, cancelToken);
        ///<inheritdoc/>
        public async Task<IQueryable<UserInfoResponse>> GetAllUsersAsync(CancellationToken cancelToken = default)
            => await _repository.GetAllAsync();
        ///<inheritdoc/>
        public async Task<UserInfoResponse> GetUserByIdAsync(Guid userId, CancellationToken cancelToken = default)
            => await _repository.GetByIdAsync(userId, cancelToken);
        ///<inheritdoc/>
        public async Task UpdateUserAsync(Guid userId,UpdateUserRequest updateUserDto, CancellationToken cancelToken = default)
            => await _repository.UpdateAsync(userId,updateUserDto, cancelToken);
        ///<inheritdoc/>
        public async Task<UserInfoResponse> GetCurrentUser(CancellationToken cancelToken)
        {
            bool isAuthenticated = _accessor.HttpContext.User.Identity!.IsAuthenticated;
            string? scheme = _accessor.HttpContext.User.Identity.AuthenticationType;

            IEnumerable<Claim> claims = _accessor.HttpContext.User.Claims;
            string? claimId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(claimId))
                throw new ArgumentNullException($"{claimId} пуст, либо равняется null");

            Guid id = Guid.Parse(claimId);
            UserInfoResponse? user = await _repository.GetByIdAsync(id, cancelToken);

            if (user == null)
                throw new InvalidOperationException($"Не найден пользователь с идентификатором '{id}'.");

            return user;
        }
        ///<inheritdoc/>
        public async Task<string> Login(string email, CancellationToken cancellationToken)
        {
            UserInfoResponse existingUser = (await _repository.GetAllAsync(cancellationToken))
                .ToList()
                .First(user => user.EMail == email);

            if (existingUser == null)
                throw new InvalidOperationException($"Пользователя с почтой '{email}' не существует");
            

            IList<Claim> claimPack = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Role, existingUser.Login),
                new Claim(ClaimTypes.Email, existingUser.EMail)
            };

            string? secretKey = _configuration["Jwt:Key"];

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials signCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claimPack,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signCredentials
                );
            
            string result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
