
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.InstrumentType
{
    public class UpdateInstrumentTypeRequest
    {
        //public Guid? ParentId { get; set; }
        /// <summary>
        /// Наименование текущего типа.
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
        //public ICollection<InstrumentTypeResponseInfo?> SubTypes { get; set; }
    }
}
