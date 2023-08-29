using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.MusicalInstrument
{
    public class DeleteMusicalInstrumentRequest
    {
        /// <summary>
        /// Идентификатор музыкального инструмента.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
