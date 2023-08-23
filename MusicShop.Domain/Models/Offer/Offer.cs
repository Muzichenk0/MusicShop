using MusicShop.Domain.Models.ModelType;
using MusicShop.Domain.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Domain.Models.Offer
{
    /// <summary>
    /// Cущность, описывающая интерфейс модели предложения. 
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
        /// Требуемая цена для принятия предложения.
        /// </summary>
        [Required]
        [MinValue(0)]
        public double RequirePrice { get; set; }
        /// <summary>
        /// Описание предложения.
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
        /// Состояние предложения.
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
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="Offer"/> и завис. <see cref="OfferCategory"/>
        /// </summary>
        [Required]
        public ICollection<OfferCategory> OfferCategories { get; set; }
        /// <summary>
        /// Пользователь, открывший предложение.
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="User.User"/> и завис. <see cref="Offer"/>
        /// </summary>
        [Required]
        public User.User User { get; set; }
        /// <summary>
        /// Уникальный идентификатор пользователя, открывшего предложение.
        /// Внешний ключ в отношении один ко многим между глав. сущностью <see cref="User.User"/> и завис. <see cref="Review.SellerReview"/>
        /// </summary>
        public Guid? UserId { get; set; }
    }
}
