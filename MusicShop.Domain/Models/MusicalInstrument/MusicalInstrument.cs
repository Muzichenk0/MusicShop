

using System.ComponentModel.DataAnnotations;
using MusicShop.Domain.Models.ModelType;
using MusicShop.Domain.Models.MusicalInstrument.MusicalInstrumentType;

namespace MusicShop.Domain.Models.MusicalInstrument
{
    /// <summary>
    /// Описывает состояние внешнего интерфейса музыкального инструмента.
    /// Сущность зависима и реализует <see cref="IIdentificable"/>.
    /// </summary>
    public class MusicalInstrument : IIdentificable
    {
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Тип инструмента.
        /// </summary>
        [Required]
        public InstrumentType InstrumentType { get; set; }
        /// <summary>
        /// Модель инструмента.
        /// </summary>
        [Required]
        public string InstrumentModel { get; set; }
        /// <summary>
        /// Дата изготовления инструмента.
        /// </summary>
        [Required]
        public DateTime DateOfCreation { get; set; }
        /// <summary>
        /// Страна, где был создан инструмент.
        /// </summary>
        [Required]
        public string CreationCountry { get; set; }
        /// <summary>
        /// Идентификатор типа инструмента, к которому текущий музыкальный инструмент относится.
        /// Внешний ключ в отношении один ко многим, между главной моделью <see cref="MusicalInstrumentType.InstrumentType"/> и зависимой <see cref="MusicalInstrument"/>
        /// </summary>
        public Guid? InstrumentTypeId { get; set; }
    }
}
