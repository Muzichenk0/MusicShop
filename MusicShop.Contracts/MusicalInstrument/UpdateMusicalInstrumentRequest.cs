using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.MusicalInstrument
{
    public class UpdateMusicalInstrumentRequest
    {
        /// <summary>
        /// Идентификатор типа инструмента
        /// </summary>
        [Required]
        public Guid? InstrumentTypeId { get; set; }
        /// <summary>
        /// Модель инструмента.
        /// </summary>
        [Required]
        public string InstrumentModel { get; set; }
        /// <summary>
        /// Дата производства музыкального инструмента.
        /// </summary>
        [Required]
        public DateTime DateOfCreation { get; set; }
        /// <summary>
        /// Страна, где был произедён музыкальный инструмент.
        /// </summary>
        [Required]
        public string CreationCountry { get; set; }
    }
}
