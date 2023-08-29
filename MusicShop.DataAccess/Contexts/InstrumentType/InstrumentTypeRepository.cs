using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.MusicalInstrument.InstrumentType.Repository;
using MusicShop.Contracts.InstrumentType;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.DataAccess.Contexts.InstrumentType
{
    public class InstrumentTypeRepository : IInstrumentTypeRepository
    {
        private readonly IRepository<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType> _instTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InstrumentTypeRepository> _logger;
        public InstrumentTypeRepository(IRepository<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType> instTypeRepository,
            IMapper mapper, ILogger<InstrumentTypeRepository> logger)
        {
            _instTypeRepository = instTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public Task AddAsync(CreateInstrumentTypeRequest instTypeToAdd, CancellationToken cancelToken = default)
            => _instTypeRepository.AddAsync(_mapper.Map<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType>(instTypeToAdd),
                cancelToken);

        public Task DeleteAsync(DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken cancelToken = default)
            => _instTypeRepository.DeleteAsync(_mapper.Map<Domain.Models.MusicalInstrument.InstrumentType.InstrumentType>(instTypeToDelete),
                cancelToken);
        public async Task UpdateAsync(Guid instTypeId, UpdateInstrumentTypeRequest instTypeToUpdate, CancellationToken cancelToken = default)
        {
            var foundInstType = await _instTypeRepository.GetByIdAsync(instTypeId, cancelToken);

             await _instTypeRepository
                .UpdateAsync(_mapper.Map(instTypeToUpdate, foundInstType));
        }
        public async Task<IQueryable<InstrumentTypeResponseInfo>> GetAllAsync(CancellationToken cancelToken = default)
        {
            var instTypes = (await _instTypeRepository.GetAllAsync(cancelToken))
                .Include(t => t.SubTypes)
                .ThenInclude(t => t!.SubTypes);

            return instTypes
                .Select(t => _mapper.Map<InstrumentTypeResponseInfo>(t))
                .AsQueryable();
        }
      
        public async Task<InstrumentTypeResponseInfo> GetByIdAsync(Guid instTypeId, CancellationToken cancelToken = default)
        {
            var foundInstType = (await _instTypeRepository.GetAllAsync())
                .Include(t => t.SubTypes)
                .ThenInclude(t => t!.SubTypes)
                .First(u => u.Id == instTypeId);


            return _mapper.Map<InstrumentTypeResponseInfo>(foundInstType);
        }
    }
}
