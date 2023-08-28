using MusicShop.Contracts.InstrumentType;

namespace MusicShop.Contracts.MusicalInstrument
{
    public class UpdateMusicalInstrumentRequest
    {
        public Guid? InstrumentTypeId { get; set; }
        public string InstrumentModel { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreationCountry { get; set; }
    }
}
