using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.SellerReview
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс, доступный при отправке запроса на удаление отзыва.
    /// </summary>
    public class DeleteSellerReviewRequest
    {
        /// <summary>
        /// Идентификатор отзыва.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
