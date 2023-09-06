namespace MusicShop.Contracts.User
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс, доступный запросу на удаление пользователя.
    /// </summary>
    public sealed class DeleteUserRequest
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid Id { get; set; }
    }
}
