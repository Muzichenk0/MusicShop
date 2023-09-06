using AutoMapper;
using MusicShop.Contracts.InstrumentType;

namespace MusicShop.Infrastructure.MapProfile.InstrumentType
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.InstrumentType.InstrumentType"/> с иными и наоборот.
    /// </summary>
    public sealed class InstrumentTypeProfile : Profile
    {
        public InstrumentTypeProfile()
        {
            CreateMap<Domain.Models.InstrumentType.InstrumentType, InstrumentTypeInfoResponse>()
              .ReverseMap();
            CreateMap<Domain.Models.InstrumentType.InstrumentType, CreateInstrumentTypeRequest>()
              .ReverseMap();
            CreateMap<Domain.Models.InstrumentType.InstrumentType, DeleteInstrumentTypeRequest>()
              .ReverseMap();
            CreateMap<Domain.Models.InstrumentType.InstrumentType, UpdateInstrumentTypeRequest>()
              .ReverseMap();
        }
    }
}
