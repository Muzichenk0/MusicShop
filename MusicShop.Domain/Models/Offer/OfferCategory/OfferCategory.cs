using MusicShop.Domain.Models.ModelType;

namespace MusicShop.Domain.Models.Offer
{
    /// <summary>
    /// Категория сделки.
    /// </summary>
    public class OfferCategory : IIdentificable
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// Подкатегории предложения.
        /// </summary>
        public IReadOnlyCollection<OfferCategory> Categories { get; set; }
        /// <summary>
        ///  Уникальный идентификатор предложения, частью которого является текущая категория.
        /// Внешний ключ для отношения один ко многим между главной сущностью <see cref="Offer.Offer"/> и зависимой <see cref="OfferCategory"/>
        /// </summary>
        public Guid? OfferId { get; set; }
        /// <summary>
        /// Предложение, частью которого является текущая категория.
        /// Навигационное свойство для отношения один ко многим между главной сущностью <see cref="Offer.Offer"/> и зависимой <see cref="OfferCategory"/>
        /// </summary>
        public Offer Offer { get; set; }
    }
}
