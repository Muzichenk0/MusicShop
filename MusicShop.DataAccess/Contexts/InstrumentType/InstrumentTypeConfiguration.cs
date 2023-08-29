using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Contexts.InstrumentType
{
    /// <summary>
    /// Конфигурация модели для таблицы БД, основанная на <see cref="Domain.Models.MusicalInstrument.MusicalInstrumentType.InstrumentType"/>.
    /// Сервис, зависимый и реализующий <see cref="IEntityTypeConfiguration{TEntity}"/>
    /// </summary>
    public class InstrumentTypeConfiguration : IEntityTypeConfiguration<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType>
    {
        /// <summary>
        /// Процедура для настройки модели, через ORM технологию, для дальнейшего создания таблицы в реляционной БД.
        /// </summary>
        /// <param name="builder">Строитель типа сущности</param>
        public void Configure(EntityTypeBuilder<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType> builder)
        {
            builder
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .HasDefaultValue(Guid.NewGuid());

            builder
                .HasMany(t => t.SubTypes)
                .WithOne(t => t.Parent)
                .HasForeignKey(t => t.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(t => t.MusicalInstruments)
                .WithOne(i => i.InstrumentType)
                .HasForeignKey(o => o.InstrumentTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
