using MusicShop.Domain.Models.ModelType;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Domain.Models.Offer
{
    /// <summary>
    /// Категория сделки.
    /// </summary>
    public class OfferCategory : IIdentificable
    {
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Имя категории
        /// </summary>
        [Required]
        public string Name { get; set; } 
        /// <summary>
        /// Имя категории сделки
        /// </summary>
        [Required]
        public IReadOnlyCollection<OfferCategory> Categories { get; set; }
        /// <summary>
        /// Внешний ключ для отношения один ко многим между главной сущностью <see cref="Offer"/> и зависимой <see cref="OfferCategory"/>
        /// </summary>
        
        public Guid? OfferId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Offer Offer { get; set; }
    }
}
