using MusicShop.Domain.Models.Base;

namespace MusicShop.Domain.Models.Offer
{
    /// <summary>
    /// Cущность, описывающая интерфейс модели предложения. 
    /// Зависима и реализует <see cref="BaseEntity"/>
    /// </summary>
    public class Offer : BaseEntity
    {
        /// <summary>
        /// Требуемая цена для принятия предложения.
        /// </summary>
        public double RequirePrice { get; set; }
        /// <summary>
        /// Описание предложения.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Состояние предложения.
        /// </summary>
        public OfferState.OfferState OfferState { get; set; } 
        /// <summary>
        /// Скидка для предложения.
        /// </summary>
        public double Discount { get; set; }
        /// <summary>
        /// Категории предложения.
        /// Навигационное свойство в отношении один ко многим между завис. сущностью <see cref="InstrumentType.InstrumentType"/> и главной <see cref="Offer"/>
        /// </summary>
        public InstrumentType.InstrumentType OfferCategory { get; set; }
        /// <summary>
        /// Пользователь, открывший предложение. Продавец.
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="User.User"/> и завис. <see cref="Offer"/>
        /// </summary>
        public User.User User { get; set; }
        /// <summary>
        /// Уникальный идентификатор пользователя, открывшего предложение.
        /// Внешний ключ в отношении один ко многим между глав. сущностью <see cref="User.User"/> и завис. <see cref="Review.SellerReview"/>
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Пользователь, закрывший предложение.
        /// Навигационное свойство в отношении один ко многим между глав. сущность <see cref="User.User"/> и зависимой <see cref="Offer"/>
        /// </summary>
        public User.User? ClosedUser { get; set; }
        /// <summary>
        /// Уникальный идентификатор пользователя, закрывшего предложение.
        /// Внешний ключ в отношении один ко многим между глав. сущностью <see cref="User.User"/> и зависимой <see cref="Offer"/>
        /// </summary>
        public Guid? ClosedUserId { get; set; }
        /// <summary>
        /// Уникальный идентификатор категории предложения.
        /// Внешний ключ в отношении один ко многим между глав. сущностью <see cref="InstrumentType.InstrumentType"/> и зависимой <see cref="Offer"/>
        /// </summary>
        public Guid? OfferCategoryId { get; set; }
    }
}
