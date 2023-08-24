using MusicShop.Domain.Models.ModelType;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Domain.Models.MusicalInstrument.MusicalInstrumentType
{
    /// <summary>
    /// Cущность, предоставляющая константы -  типы музыкальных инструментов.
    /// </summary>
    public class InstrumentType : IIdentificable
    {
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Внешний ключ, указывающий на родительскую, базовую категорию типа инструмента.
        /// </summary>
        [Required]
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Имя категории инструментов.
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
        /// <summary>
        /// Подтипы, производные, для текущей категории.
        /// </summary>
        [Required]
        public ICollection<InstrumentType> SubTypes { get; set; }
        /// <summary>
        /// Музыкальные инструменты, входящие в текущую категорию.
        /// Навигационное свойство в отношении один ко многим, между глав. сущностью <see cref="InstrumentType"/> и завис. <see cref="MusicalInstrument"/>
        /// </summary>
        [Required]
        public ICollection<MusicalInstrument> MusicalInstruments { get; set; }
    }
}
