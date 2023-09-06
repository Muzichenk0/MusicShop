using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.SellerReview
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс, доступный отзыву на удаление существующего отзыва о продавце.
    /// </summary>
    public sealed class DeleteSellerReviewRequest
    {
        /// <summary>
        /// Идентификатор отзыва.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
