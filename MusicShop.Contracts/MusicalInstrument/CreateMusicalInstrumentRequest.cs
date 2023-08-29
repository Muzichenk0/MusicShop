namespace MusicShop.Contracts.MusicalInstrument
{
    public class CreateMusicalInstrumentRequest
    {
        /// <summary>
        /// Идентификатор типа инструмента.
        /// </summary>
        public Guid? InstrumentTypeId { get; set; }
        /// <summary>
        /// Модель музыкального инструмента.
        /// </summary>
        public string InstrumentModel { get; set; }
        /// <summary>
        /// Дата производства описываемого инструмента.
        /// </summary>
        public DateTime DateOfCreation { get; set; }
        /// <summary>
        /// Имя страны где инструмент был создан.
        /// </summary>
        public string CreationCountry { get; set; }
    }
}
