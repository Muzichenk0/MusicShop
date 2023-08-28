using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.SellerReview
{
    /// <summary>
    /// Интерфейс, доступный при отправке запроса  на получение данных об отзывах.
    /// </summary>
    public class SellerReviewResponseInfo
    {
        /// <summary>
        /// Идентификатор отзыва.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок отзыва.
        /// </summary>
        [Required]
        [StringLength(65)]
        public string Topic { get; set; }
        /// <summary>
        /// Оценка услуги из отзыва.
        /// </summary>
        [Required]
        [Range(0,5)]
        public double Rating { get; set; }
        /// <summary>
        /// Описание отзыва.
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        /// <summary>
        /// Идентификатор продавца, отзыв описан о котором
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Идентификатор пользователя, отправившего отзыв.
        /// </summary>
        public Guid? SenderId { get; set; }
        /// <summary>
        /// Дата создания отзыва.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}
