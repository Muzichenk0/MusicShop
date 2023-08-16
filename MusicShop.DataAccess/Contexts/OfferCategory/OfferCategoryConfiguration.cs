using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Contexts.OfferCategory
{
    /// <summary>
    /// Конфигурация модели для таблицы БД, основанная на <see cref="Domain.Models.Offer.OfferCategory"/>.
    /// Сервис, зависимый и реализующий <see cref="IEntityTypeConfiguration{TEntity}"/>
    /// </summary>
    public class OfferCategoryConfiguration : IEntityTypeConfiguration<Domain.Models.Offer.OfferCategory>
    {
        /// <summary>
        /// Процедура для настройки модели, через ORM технологию, для дальнейшего создания таблицы в реляционной БД.
        /// </summary>
        /// <param name="builder">Строитель типа сущности</param>
        public void Configure(EntityTypeBuilder<Domain.Models.Offer.OfferCategory> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
        }
    }
}
