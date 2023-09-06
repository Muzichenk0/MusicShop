namespace MusicShop.Contracts.Offer
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный запросу на удаление информации, связанной с моделью предложения.
    /// </summary>
    public class DeleteOfferRequest
    {
        /// <summary>
        /// Идентификатор предложения.
        /// </summary>
        public Guid Id { get; set; }
    }
}
