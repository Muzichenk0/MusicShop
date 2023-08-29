using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MusicShop.DataAccess.Contexts.SellerReview
{
    /// <summary>
    /// Конфигурация модели для таблицы БД, основанная на <see cref="Domain.Models.Review.SellerReview"/>.
    /// Сервис, зависимый и реализующий <see cref="IEntityTypeConfiguration{TEntity}"/>
    /// </summary>
    public class SellerReviewConfiguration : IEntityTypeConfiguration<Domain.Models.Review.SellerReview>
    {
        /// <summary>
        /// Процедура для настройки модели, основы для создания таблицы в БД, через ORM технологию.
        /// </summary>
        /// <param name="entityBuilder">Стройщик настроек модели</param>
        public void Configure(EntityTypeBuilder<Domain.Models.Review.SellerReview> entityBuilder)
        {
            entityBuilder
                .HasKey(r => r.Id);
            entityBuilder
                .Property(r => r.Id)
                .HasDefaultValue(Guid.NewGuid());
            entityBuilder
                .Property(r => r.Topic)
                .HasMaxLength(65);
            entityBuilder
                .Property(r => r.Description)
                .HasMaxLength(300);
        }
    }
}
