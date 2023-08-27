namespace MusicShop.Contracts.InstrumentType
{
    public class InstrumentTypeResponseInfo
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<InstrumentTypeResponseInfo> SubTypes { get; set; }
    }
}
