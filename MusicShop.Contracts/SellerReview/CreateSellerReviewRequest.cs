using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.SellerReview
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс, доступный при отправке запроса на создание нового отзыва.
    /// </summary>
    public class CreateSellerReviewRequest
    {
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
        [Range(0, 5)]
        public double Rating { get; set; }
        /// <summary>
        /// Описание отзыва.
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        /// <summary>
        /// Идентификатор пользователя, отправившего отзыв о покупателе.
        /// </summary>
        public Guid? SenderId { get; set; }
        /// <summary>
        /// Идентификатор пользователя, отзыв о котором, как продавце, создается.
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Дата создания отзыва.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}
