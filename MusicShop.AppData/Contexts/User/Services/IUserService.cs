using MusicShop.Contracts.User;

namespace MusicShop.AppData.Contexts.User.Services
{
    /// <summary>
    /// Абстрактный тип - контракт, описывающая внешний интерфейс модели сервиса для пользователя.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Добавление пользователя, асинхронно.
        /// </summary>
        /// <param name="createUserDto">Информация о пользователе для создания</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        public Task AddUserAsync(CreateUserRequest createUserDto, CancellationToken cancelToken = default);
        /// <summary>
        /// Обновление пользователя, асинхронно.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="updateUserDto">Информация о пользователе для обновления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        public Task UpdateUserAsync(Guid userId, UpdateUserRequest updateUserDto, CancellationToken cancelToken = default);
        /// <summary>
        /// Удаление пользователя, асинхронно.
        /// </summary>
        /// <param name="deleteUserDto">Информация о пользователе для удаления</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        public Task DeleteUserAsync(DeleteUserRequest deleteUserDto, CancellationToken cancelToken = default);
        /// <summary>
        /// Получение всех пользователей, асинхронно.
        /// </summary>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        /// <returns>Выстроенное в оптимизированный запрос, перечисление из <see cref="UserInfoResponse"/> </returns>
        public Task<IQueryable<UserInfoResponse>> GetAllUsersAsync(CancellationToken cancelToken = default);
        /// <summary>
        /// Получение пользователя с помощью идентификатора, асинхронно
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="cancelToken">Жетон для отмены асинхронной задачи</param>
        /// <returns>Экземпляр <see cref="UserInfoResponse"/>, чье ID, согласованно с <paramref name="userId"/> </returns>
        public Task<UserInfoResponse> GetUserByIdAsync(Guid userId, CancellationToken cancelToken = default);
    }
}
