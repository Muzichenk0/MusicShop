using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.DataAccess.Contexts.User
{
    /// <summary>
    /// Репозиторий для типа <see cref="Domain.Models.User.User"/>
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<Domain.Models.User.User> _repository;
        public UserRepository(IRepository<Domain.Models.User.User> repository) => _repository = repository;
        public Task<IQueryable<Domain.Models.User.User>> GetAllAsync(CancellationToken cancelToken = default)
            => _repository.GetAllAsync(cancelToken);
        public Task<Domain.Models.User.User> GetByIdAsync(Guid userId, CancellationToken cancelToken = default)
            => _repository.GetByIdAsync(userId, cancelToken);
        public Task AddAsync(Domain.Models.User.User userToCreate, CancellationToken cancelToken = default)
            => _repository.AddAsync(userToCreate, cancelToken);
        public Task DeleteAsync(Domain.Models.User.User userToDelete, CancellationToken cancelToken = default)
            => _repository.DeleteAsync(userToDelete, cancelToken);
        public Task UpdateAsync(Domain.Models.User.User userToUpdate, CancellationToken cancelToken = default)
            => _repository.UpdateAsync(userToUpdate, cancelToken);
    }
}
