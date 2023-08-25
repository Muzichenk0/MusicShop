namespace MusicShop.Contracts.User.Enums
{
    /// <summary>
    /// Статус учетной записи пользователя
    /// </summary>
    public enum UserStatus
    { 
        /// <summary>
        /// Верифицирован
        /// </summary>
        Verified,
        /// <summary>
        /// Не верифицирован
        /// </summary>
        NotVerified,
        /// <summary>
        /// Заблокирован
        /// </summary>
        Blocked
    }
}
