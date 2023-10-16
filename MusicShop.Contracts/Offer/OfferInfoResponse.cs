using MusicShop.Contracts.Offer.Enums;
using MusicShop.Contracts.InstrumentType;
using MusicShop.Contracts.User;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.Offer
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный при создании ответа на запрос информации, связанной с моделью предложения.
    /// </summary>
    public sealed class OfferInfoResponse
    {
        /// <summary>
        /// Уникальный идентификатор предложения
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Требуемая цена для закрытия предложения
        /// </summary>
        [Required]
        public double RequirePrice { get; set; }
        /// <summary>
        /// Описание предложения
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Состояние предложения
        /// </summary>
        [Required]
        public OfferState OfferState { get; set; }
        /// <summary>
        /// Скидка на предложение
        /// </summary>
        [Required]
        public double Discount { get; set; }
        /// <summary>
        /// Категория предложения
        /// </summary>
        [Required]
        public InstrumentTypeInfoResponse OfferCategory{ get; set; }
        /// <summary>
        /// Пользователь, открывший предложение. Продавец
        /// </summary>
        [Required]
        public UserInfoResponse User { get; set; }
        /// <summary>
        /// Пользователь, закрывший предложение. Покупатель
        /// </summary>
        public UserInfoResponse? ClosedUser { get; set; }
    }
}
