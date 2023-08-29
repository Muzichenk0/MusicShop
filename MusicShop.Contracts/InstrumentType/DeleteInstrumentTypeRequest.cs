using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.InstrumentType
{
    public class DeleteInstrumentTypeRequest
    {
        /// <summary>
        /// Идентификатор типа инструмента.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
