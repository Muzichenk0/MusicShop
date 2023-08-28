using MusicShop.Domain.Models.ModelType;

namespace MusicShop.Domain.Models.MusicalInstrument
{
    /// <summary>
    /// Описывает состояние внешнего интерфейса музыкального инструмента.
    /// Сущность зависима и реализует <see cref="IIdentificable"/>.
    /// </summary>
    public class MusicalInstrument : IIdentificable
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Тип инструмента.
        /// </summary>
        public InstrumentType.InstrumentType InstrumentType { get; set; }
        /// <summary>
        /// Модель инструмента.
        /// </summary>
        public string InstrumentModel { get; set; }
        /// <summary>
        /// Дата изготовления инструмента.
        /// </summary>
        public DateTime DateOfCreation { get; set; }
        /// <summary>
        /// Страна, где был создан инструмент.
        /// </summary>
        public string CreationCountry { get; set; }
        /// <summary>
        /// Идентификатор типа инструмента, к которому текущий музыкальный инструмент относится.
        /// Внешний ключ в отношении один ко многим, между главной моделью <see cref="MusicalInstrumentType.InstrumentType"/> и зависимой <see cref="MusicalInstrument"/>
        /// </summary>
        public Guid? InstrumentTypeId { get; set; }
    }
}
