using MusicShop.Domain.Models.ModelType;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Domain.Models.Review
{
    /// <summary>
    /// Оценка продавца.
    /// </summary>
    public class SellerReview : IIdentificable
    {
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок оценки.
        /// </summary>
        [Required]
        public string Topic { get; set; }
        /// <summary>
        /// Оценка продаца.
        /// </summary>
        [Required]
        [Range(0, 5)]
        public double Rating { get; set; }
        /// <summary>
        /// Описание оценки.
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Пользователь, получивший оценку.
        /// Навигационное свойство в отношении один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        [Required]
        public User.User User { get; set; }
        /// <summary>
        /// Идентификатор пользователя, получившего оценку.
        /// Внешний ключ для отношения один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Пользователь, покупатель, оставляющий оценку.
        /// Навигационное свойство для отношения один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        [Required]
        public User.User Sender { get; set; }
        /// <summary>
        /// Идентификатор пользователя, оставившего оценку.
        /// Внешний ключ для отношения один ко многим,
        /// Между главной сущностью - <see cref="User.User"/> и зависимой <see cref="SellerReview"/>
        /// </summary>
        public Guid? SenderId { get; set; }
        /// <summary>
        /// Дата оценки.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }

}