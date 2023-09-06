using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.InstrumentType
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный при создании ответа на запрос информации, связанной с моделью типа инструмента.
    /// </summary>
    public sealed class InstrumentTypeInfoResponse
    {
        /// <summary>
        /// Идентификатор типа инструмента.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор родительского типа инструмента.
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Наименование текущего типа
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
        /// <summary>
        /// Коллекция из типов инструментов. Может содержать значения по умолчанию, для ссылочного типа null.
        /// </summary>
        public ICollection<InstrumentTypeInfoResponse?> SubTypes { get; set; }
    }
}
