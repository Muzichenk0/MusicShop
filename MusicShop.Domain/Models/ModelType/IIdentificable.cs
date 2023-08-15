

namespace MusicShop.Domain.Models.ModelType
{
    /// <summary>
    /// Абстрактный интерфейс-контракт, описывающий внешний интерфейс для выполнения обязанностей идентифицируемой сущности.
    /// </summary>
    public interface IIdentificable
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public Guid Id { get; set; }
    }
}
