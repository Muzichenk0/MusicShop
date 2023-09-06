namespace MusicShop.Contracts.Offer.Enums
{
    /// <summary>
    /// Перечисление из констант - состояний предложения.
    /// </summary>
    public enum OfferState
    {
        /// <summary>
        /// Открытое предложение
        /// </summary>
        Open,
        /// <summary>
        /// Проверяющееся модерацией предложение
        /// </summary>
        Moderatable,
        /// <summary>
        /// В ожидании оплаты от пользователя
        /// </summary>
        Paused,
        /// <summary>
        /// Закрытое предложение
        /// </summary>
        Closed
    }
}
