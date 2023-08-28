using MusicShop.Domain.Models.ModelType;

namespace MusicShop.Domain.Models.MusicalInstrument.InstrumentType
{
    /// <summary>
    /// Cущность, предоставляющая константы -  типы музыкальных инструментов.
    /// </summary>
    public class InstrumentType : IIdentificable
    {
        public Guid Id { get; set; }
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
        /// Музыкальные инструменты, входящие в текущую категорию.
        /// Навигационное свойство в отношении один ко многим, между глав. сущностью <see cref="InstrumentType"/> и завис. <see cref="MusicalInstrument"/>
        /// </summary>
        public ICollection<MusicalInstrument> MusicalInstruments { get; set; }
        /// <summary>
        /// Предложение, частью которого является текущий тип инструмента.
        /// Навигационное свойство для отношения один ко многим, между глав. сущностью <see cref="Offer.Offer"/> и завис. <see cref="InstrumentType"/>.S
        /// </summary>
        public Offer.Offer? Offer { get; set; }
        /// <summary>
        /// Идентификатор предложения, частью которого является текущая категория.
        /// Внешний ключ для отношения один ко многим, между глав. сущностью <see cref="Offer.Offer"/> и завис. <see cref="InstrumentType"/>.S
        /// </summary>
        public Guid? OfferId { get; set; }

    }
}
