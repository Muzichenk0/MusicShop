using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.Contracts.User;
using MusicShop.Infrastructure.Repositories.Base;
using System.Text.Json;

namespace MusicShop.DataAccess.Contexts.User
{
    /// <summary>
    /// Модель, реализующая внешний интерфейс для модели - репозиторий пользователя, описанный в  <see cref="IUserRepository"/>.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<Domain.Models.User.User> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IRepository<Domain.Models.User.User> repository, IMapper mapper, ILogger<UserRepository> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        ///<inheritdoc/>
        public async Task<IQueryable<UserInfoResponse>> GetAllAsync(CancellationToken cancelToken = default)
        {
            IQueryable<Domain.Models.User.User> users = await _repository.GetAllAsync(cancelToken);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(users)} trying to be taken from database");

            return users
                .Include(u => u.SendedReviews)
                .Include(u => u.Qualifications)
                .Select(u => _mapper.Map<UserInfoResponse>(u))
                .AsQueryable();
        }
        ///<inheritdoc/>
        public async Task<UserInfoResponse> GetByIdAsync(Guid userId, CancellationToken cancelToken = default)
        {
            Domain.Models.User.User user = (await _repository.GetAllAsync())
                .Include(u => u.SendedReviews)
                .Include(u => u.Qualifications)
                .First(u => u.Id == userId);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(user.Id)} tring to be taken from database");

            return _mapper.Map<UserInfoResponse>(user);
        }
        ///<inheritdoc/>
        public async Task<Guid> AddAsync(CreateUserRequest userToCreate, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToCreate)} tring to be added into database");

            Domain.Models.User.User userToAdd = _mapper.Map<Domain.Models.User.User>(userToCreate);
            await _repository.AddAsync(userToAdd, cancelToken);
            return userToAdd.Id;
        }
        ///<inheritdoc/>
        public Task DeleteAsync(DeleteUserRequest userToDelete, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToDelete)} trying to be deleted into database");

            return _repository.DeleteAsync(_mapper.Map<Domain.Models.User.User>(userToDelete), cancelToken);
        }
        ///<inheritdoc/>
        public async Task UpdateAsync(Guid userId, UpdateUserRequest userToUpdate, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToUpdate)} trying to be updated into database");

            Domain.Models.User.User user = await _repository.GetByIdAsync(userId,cancelToken);

             await _repository
            .UpdateAsync(_mapper.Map(userToUpdate, user), cancelToken);
        }
    }
}
