namespace MusicShop.Domain.Models.Offer.OfferState
{
   /// <summary>
   /// Включает в себя константы - состояния предложения.
   /// </summary>
    public enum OfferState
    {
        /// <summary>
        /// Закрытое предложение
        /// </summary>
        Closed,
        /// <summary>
        /// Проверяющееся, перед публикованием, предложение
        /// </summary>
        Moderatable,
        /// <summary>
        /// В ожидании оплаты от пользоателя-покупателя
        /// </summary>
        Paused,
        /// <summary>
        /// Открытое предложение
        /// </summary>
        Opened
    }
}
