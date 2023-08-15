using MusicShop.Domain.Models.ModelType;
using MusicShop.Domain.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Domain.Models.Offer
{
    /// <summary>
    /// Cущность, описывающая интерфейс модели сделки. 
    /// Зависима и реализует <see cref="IIdentificable"/>"/>
    /// </summary>
    public class Offer : IIdentificable
    {
        /// <summary>
        /// Уникальный идентификатор предложения.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Требуемая цена за совершение сделки.
        /// </summary>
        [Required]
        [MinValue(0)]
        public double RequirePrice { get; set; }
        /// <summary>
        /// Описание сделки.
        /// </summary>
        [Required]
        [StringLength(1500)]
        public string Description { get; set; }
        /// <summary>
        /// Коллекция, доступная только для прочтения, с музыкальными инструментами.
        /// </summary>
        [Required]
        public IReadOnlyCollection<MusicalInstrument.MusicalInstrument> InstrumentsToOffer { get; set; }
        /// <summary>
        /// Состояние сделки.
        /// </summary>
        [Required]
        public OfferState.OfferState OfferState { get; set; } = Models.Offer.OfferState.OfferState.Moderatable;
        /// <summary>
        /// Скидка для предложения. Изначально равна 0.0
        /// </summary>
        [Required]
        public double Discount { get; set; } = 0.0;
        /// <summary>
        /// Категории предложения.
        /// </summary>
        [Required]
        public ICollection<OfferCategory> OfferCategories { get; set; } // навигационное свойство
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public User.User User { get; set; }
    }
}
