using MusicShop.Contracts.User;

namespace MusicShop.AppData.Contexts.User.Services
{
    public interface IUserService
    {
        public Task AddUserAsync(CreateUserRequest createUserDto, CancellationToken cancelToken = default);
        public Task UpdateUserAsync(UpdateUserRequest updateUserDto, CancellationToken cancelToken = default);
        public Task DeleteUserAsync(DeleteUserRequest deleteUserDto, CancellationToken cancelToken = default);
        public Task<IQueryable<UserInfoResponse>> GetAllUsersAsync(CancellationToken cancelToken = default);
        public Task<UserInfoResponse> GetUserByIdAsync(Guid userId, CancellationToken cancelToken = default);
    }
}
