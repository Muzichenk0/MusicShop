
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.InstrumentType
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный запросу на обновление существующего типа инструмента.
    /// </summary>
    public sealed class UpdateInstrumentTypeRequest
    {
        //public Guid? ParentId { get; set; }
        /// <summary>
        /// Наименование текущего типа.
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
    }
}
