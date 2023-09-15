using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.Contracts.User;

namespace MusicShop.AppData.Contexts.User.Services
{
    /// <summary>
    /// Конкретный ссылочный тип, реализующий интерфейс для сущности - сервис пользователя.
    /// </summary>
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        ///<inheritdoc/>
        public async Task<Guid> AddUserAsync(CreateUserRequest createUserDto, CancellationToken cancelToken = default)
          =>  await _repository.AddAsync(createUserDto, cancelToken);
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
    }
}
