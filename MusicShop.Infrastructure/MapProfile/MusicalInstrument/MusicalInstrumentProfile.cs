using AutoMapper;
using MusicShop.Contracts.MusicalInstrument;

namespace MusicShop.Infrastructure.MapProfile.MusicalInstrument
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.MusicalInstrument.MusicalInstrument"/> с иными и наоборот.
    /// </summary>
    public class MusicalInstrumentProfile : Profile
    {
        public MusicalInstrumentProfile()
        {
            CreateMap<Domain.Models.MusicalInstrument.MusicalInstrument, CreateMusicalInstrumentRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.MusicalInstrument.MusicalInstrument, DeleteMusicalInstrumentRequest>()
               .ReverseMap();
            CreateMap<Domain.Models.MusicalInstrument.MusicalInstrument, UpdateMusicalInstrumentRequest>()
               .ReverseMap();
            CreateMap<Domain.Models.MusicalInstrument.MusicalInstrument, MusicalInstrumentResponseInfo>()
               .ReverseMap();
        }
    }
}
