using MusicShop.Contracts.File;
using MusicShop.Contracts.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.Offer
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный запросу на создание нового предложения.
    /// </summary>
    public sealed class CreateOfferRequest
    {
        /// <summary>
        /// Требуемая цена для закрытия предложения
        /// </summary>
        [Required]
        public double RequirePrice { get; set; }
        /// <summary>
        /// Описание предложение
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Скидка
        /// </summary>
        [Required]
        public double Discount { get; set; }
        /// <summary>
        /// Идентификатор категории предложения.
        /// </summary>
        [Required]
        public Guid? OfferCategoryId { get; set; }
        /// <summary>
        /// Идентификатор пользователя, создавшего предложение.
        /// </summary>
        [Required]
        public Guid? UserId { get; set; }
        /// <summary>
        /// Коллекция фото, связанных с предложением.
        /// </summary>
        [Required]
        [PhotoCollection]
        public ICollection<SiteFileInfoResponse?> OfferFiles { get; set; }
    }
}
