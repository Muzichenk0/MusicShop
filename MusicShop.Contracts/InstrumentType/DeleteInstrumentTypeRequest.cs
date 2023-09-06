using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.InstrumentType
{
    /// <summary>
    /// Модель, определящая интерфейс, доступный для запроса на удаление существующего типа инструмента.
    /// </summary>
    public sealed class DeleteInstrumentTypeRequest
    {
        /// <summary>
        /// Идентификатор типа инструмента.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
