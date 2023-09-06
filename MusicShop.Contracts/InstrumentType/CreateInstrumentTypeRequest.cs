using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.InstrumentType
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный запросу на создание нового типа инструмента
    /// </summary>
    public sealed class CreateInstrumentTypeRequest
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
