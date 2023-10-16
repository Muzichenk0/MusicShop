using MusicShop.Domain.Models.Base;

namespace MusicShop.Domain.Models.InstrumentType
{
    /// <summary>
    /// Cущность, предоставляющая константы -  типы музыкальных инструментов.
    /// </summary>
    public class InstrumentType : BaseEntity
    {
        /// <summary>
        /// Внешний ключ, указывающий на родительскую, базовую категорию типа инструмента.
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Имя категории инструментов.
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Подтипы, производные, для текущей категории.
        /// </summary>
        public ICollection<InstrumentType?> SubTypes { get; set; }
        /// <summary>
        /// Навигационное свойство, родительский тип инструмента.
        /// </summary>
        public InstrumentType? Parent { get; set; }
        /// <summary>
        /// Предложение, частью которого является текущий тип инструмента.
        /// Навигационное свойство для отношения один ко многим, между главной <see cref="InstrumentType"/> и зависимой <see cref="Offer.Offer"/>.S
        /// </summary>
        public ICollection<Offer.Offer?> Offers { get; set; }
        /// <summary>
        /// Идентификатор предложения, частью которого является текущая категория.
        /// Внешний ключ для отношения один ко многим, между зависимой сущностью <see cref="Offer.Offer"/> и главной <see cref="InstrumentType"/>.S
        /// </summary>
        public Guid? OfferId { get; set; }
        /// <summary>
        /// Пользователи, чья специализация связана с текущим типом инструмента.
        /// Навигационное свойство для отношения многие ко многим, между сущностями: <see cref="User.User"/> и <see cref="InstrumentType"/>
        /// </summary>
        public ICollection<User.User?> Users { get; set; }

    }
}
