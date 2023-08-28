using AutoMapper;
using MusicShop.Contracts.InstrumentType;

namespace MusicShop.Infrastructure.MapProfile.InstrumentType
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.MusicalInstrument.InstrumentType.InstrumentType"/> с иными и наоборот.
    /// </summary>
    public class InstrumentTypeProfile : Profile
    {
        public InstrumentTypeProfile()
        {
            CreateMap<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType, InstrumentTypeResponseInfo>()
              .ReverseMap();
            CreateMap<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType, CreateInstrumentTypeRequest>()
              .ReverseMap();
            CreateMap<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType, DeleteInstrumentTypeRequest>()
              .ReverseMap();
            CreateMap<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType, UpdateInstrumentTypeRequest>()
              .ReverseMap();
        }
    }
}
