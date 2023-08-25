using MusicShop.Domain.Models.ModelType;

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
        public Guid Id { get; set; }
        /// <summary>
        /// Требуемая цена для принятия предложения.
        /// </summary>
        public double RequirePrice { get; set; }
        /// <summary>
        /// Описание предложения.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Коллекция, доступная только для прочтения, с музыкальными инструментами.
        /// </summary>
        public IReadOnlyCollection<MusicalInstrument.MusicalInstrument> InstrumentsToOffer { get; set; }
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
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="Offer"/> и завис. <see cref="OfferCategory"/>
        /// </summary>
        public ICollection<OfferCategory> OfferCategories { get; set; }
        /// <summary>
        /// Пользователь, открывший предложение.
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="User.User"/> и завис. <see cref="Offer"/>
        /// </summary>
        public User.User User { get; set; }
        /// <summary>
        /// Уникальный идентификатор пользователя, открывшего предложение.
        /// Внешний ключ в отношении один ко многим между глав. сущностью <see cref="User.User"/> и завис. <see cref="Review.SellerReview"/>
        /// </summary>
        public Guid? UserId { get; set; }
    }
}
