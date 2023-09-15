

namespace MusicShop.Domain.Models.Base
{
    /// <summary>
    /// Абстрактная, базовая сущность-контракт, описывающий интерфейс для выполнения обязанностей модели базовой сущности.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid Id { get; set; }
    }
}
