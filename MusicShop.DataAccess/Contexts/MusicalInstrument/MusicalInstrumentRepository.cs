using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.MusicalInstrument.Repository;
using MusicShop.Contracts.MusicalInstrument;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.DataAccess.Contexts.MusicalInstrument
{
    public class MusicalInstrumentRepository : IMusicalInstrumentRepository
    {
        private readonly IRepository<Domain.Models.MusicalInstrument.MusicalInstrument> _musInstrumentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MusicalInstrumentRepository> _logger;
        public MusicalInstrumentRepository(IRepository<Domain.Models.MusicalInstrument.MusicalInstrument> musInstrumentRepository,
            IMapper mapper, ILogger<MusicalInstrumentRepository> logger)
        {
            _musInstrumentRepository = musInstrumentRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public Task AddAsync(CreateMusicalInstrumentRequest musInstrumentToAdd, CancellationToken cancelToken = default)
            => _musInstrumentRepository.AddAsync(_mapper.Map<Domain.Models.MusicalInstrument.MusicalInstrument>(musInstrumentToAdd), cancelToken);

        public Task DeleteAsync(DeleteMusicalInstrumentRequest musInstrumentToDelete, CancellationToken cancelToken = default)
            => _musInstrumentRepository.DeleteAsync(_mapper.Map<Domain.Models.MusicalInstrument.MusicalInstrument>(musInstrumentToDelete), cancelToken);

        public async Task<IQueryable<MusicalInstrumentResponseInfo>> GetAllAsync(CancellationToken cancelToken = default)
        {
            var musInstruments = (await _musInstrumentRepository.GetAllAsync(cancelToken))
                .Include(i => i.InstrumentType)
                .ThenInclude(t => t.SubTypes)
                .ThenInclude(t => t!.SubTypes);

            return musInstruments
                .Select(i => _mapper.Map<MusicalInstrumentResponseInfo>(i))
                .AsQueryable();
        }

        public async Task<MusicalInstrumentResponseInfo> GetByIdAsync(Guid musInstrumentId, CancellationToken cancelToken = default)
        {
            var foundMusInstrument = (await _musInstrumentRepository.GetAllAsync(cancelToken))
                .Include(i => i.InstrumentType)
                .ThenInclude(t => t.SubTypes)
                .ThenInclude(t => t!.SubTypes)
                .First(i => i.Id == musInstrumentId);

            return _mapper.Map<MusicalInstrumentResponseInfo>(foundMusInstrument);
        }

        public async Task UpdateAsync(Guid musInstrumentId, UpdateMusicalInstrumentRequest musInstrumentToUpdate, CancellationToken cancelToken = default)
        {
            var foundMusInstrument = await _musInstrumentRepository.GetByIdAsync(musInstrumentId, cancelToken);

            await _musInstrumentRepository.UpdateAsync(_mapper.Map(musInstrumentToUpdate,foundMusInstrument),cancelToken);
        }
    }
}
