namespace MusicShop.Contracts.MusicalInstrument
{
    public class CreateMusicalInstrumentRequest
    {
        public Guid? InstrumentTypeId { get; set; }
        public string InstrumentModel { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreationCountry { get; set; }
    }
}
