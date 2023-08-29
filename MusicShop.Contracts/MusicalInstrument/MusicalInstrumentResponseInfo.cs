using MusicShop.Contracts.InstrumentType;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.MusicalInstrument
{
    public class MusicalInstrumentResponseInfo
    {
        /// <summary>
        /// Идентификатор музыкального инструмента.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        //public Guid? InstrumentTypeId { get; set; }
        /// <summary>
        /// Тип музыкального инструмента.
        /// </summary>
        [Required]
        public InstrumentTypeResponseInfo InstrumentType { get; set; }
        /// <summary>
        /// Модель музыкального инструмента.
        /// </summary>
        [Required]
        public string InstrumentModel { get; set; }
        /// <summary>
        /// Дата производства данного музыкального инструмента.
        /// </summary>
        [Required]
        public DateTime DateOfCreation { get; set; }
        /// <summary>
        /// Имя страны, где был произведен инструмент.
        /// </summary>
        [Required]
        public string CreationCountry { get; set; }
    }
}
