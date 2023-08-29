using MusicShop.Contracts.InstrumentType;

namespace MusicShop.Contracts.MusicalInstrument
{
    public class MusicalInstrumentResponseInfo
    {
        public Guid Id { get; set; }
        //public Guid? InstrumentTypeId { get; set; }
        public InstrumentTypeResponseInfo InstrumentType { get; set; }
        public string InstrumentModel { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string CreationCountry { get; set; }
    }
}
