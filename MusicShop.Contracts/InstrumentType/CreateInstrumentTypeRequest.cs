namespace MusicShop.Contracts.InstrumentType
{
    public class CreateInstrumentTypeRequest
    {
        public Guid? ParentId { get; set; }
        public string CategoryName { get; set; }
    }
}
