using MusicShop.Contracts.InstrumentType;
using MusicShop.Contracts.Offer.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.Offer
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный запросу на обновление предложения.
    /// </summary>
    public sealed class UpdateOfferRequest
    {
        [Required]
        public double RequirePrice { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public OfferState OfferState { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public Guid OfferCategoryId { get; set; }
        public Guid? ClosedUserId { get; set; }
    }
}
