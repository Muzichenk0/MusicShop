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
    /// Репозиторий для типа <see cref="Domain.Models.User.User"/>
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
        public async Task<IQueryable<UserInfoResponse>> GetAllAsync(CancellationToken cancelToken = default)
        {
            IQueryable<Domain.Models.User.User> users = await _repository.GetAllAsync(cancelToken);

            //_logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(users)} trying to be taken from database");

            return users
                .Include(u => u.SendedReviews)
                .Select(u => _mapper.Map<UserInfoResponse>(u))
                .AsQueryable();
        }
        public async Task<UserInfoResponse> GetByIdAsync(Guid userId, CancellationToken cancelToken = default)
        {
            Domain.Models.User.User user = (await _repository.GetAllAsync())
                .Include(u => u.SendedReviews)
                .First(u => u.Id == userId);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(user.Id)} tring to be taken from database");

            return _mapper.Map<UserInfoResponse>(user);
        }
        public Task AddAsync(CreateUserRequest userToCreate, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToCreate)} tring to be added into database");

            return _repository.AddAsync(_mapper.Map<Domain.Models.User.User>(userToCreate), cancelToken);
        }
        public Task DeleteAsync(DeleteUserRequest userToDelete, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToDelete)} trying to be deleted into database");

            return _repository.DeleteAsync(_mapper.Map<Domain.Models.User.User>(userToDelete), cancelToken);
        }
        public async Task UpdateAsync(Guid userId, UpdateUserRequest userToUpdate, CancellationToken cancelToken = default)
        {
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(userToUpdate)} trying to be updated into database");
            Domain.Models.User.User user = await _repository.GetByIdAsync(userId,cancelToken);
            //return _repository.UpdateAsync(_mapper.Map<Domain.Models.User.User>(userToUpdate), cancelToken);
             await _repository
            .UpdateAsync(_mapper.Map(userToUpdate, user), cancelToken);
        }
    }
}
