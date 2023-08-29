using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.InstrumentType
{
    public class CreateInstrumentTypeRequest
    {
        /// <summary>
        /// Идентификатор родительского типа инструмента.
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Наименование текущего типа.
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
    }
}
