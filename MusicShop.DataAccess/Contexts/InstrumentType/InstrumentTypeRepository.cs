using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.InstrumentType.Repository;
using MusicShop.Contracts.InstrumentType;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.DataAccess.Contexts.InstrumentType
{
    /// Модель, реализующая внешний интерфейс для модели - репозиторий типа инструмента, описанный в  <see cref="IInstrumentTypeRepository"/>.
    public class InstrumentTypeRepository : IInstrumentTypeRepository
    {
        private readonly IRepository<Domain.Models.InstrumentType.InstrumentType> _instTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InstrumentTypeRepository> _logger;
        public InstrumentTypeRepository(IRepository<Domain.Models.InstrumentType.InstrumentType> instTypeRepository,
            IMapper mapper, ILogger<InstrumentTypeRepository> logger)
        {
            _instTypeRepository = instTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        ///<inheritdoc/>
        public Task AddAsync(CreateInstrumentTypeRequest instTypeToAdd, CancellationToken cancelToken = default)
            => _instTypeRepository.AddAsync(_mapper.Map<Domain.Models.InstrumentType.InstrumentType>(instTypeToAdd),
                cancelToken);
        ///<inheritdoc/>
        public Task DeleteAsync(DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken cancelToken = default)
            => _instTypeRepository.DeleteAsync(_mapper.Map<Domain.Models.InstrumentType.InstrumentType>(instTypeToDelete),
                cancelToken);
        ///<inheritdoc/>
        public async Task UpdateAsync(Guid instTypeId, UpdateInstrumentTypeRequest instTypeToUpdate, CancellationToken cancelToken = default)
        {
            var foundInstType = await _instTypeRepository.GetByIdAsync(instTypeId, cancelToken);

             await _instTypeRepository
                .UpdateAsync(_mapper.Map(instTypeToUpdate, foundInstType));
        }
        ///<inheritdoc/>
        public async Task<IQueryable<InstrumentTypeInfoResponse>> GetAllAsync(CancellationToken cancelToken = default)
        {
            var instTypes = (await _instTypeRepository.GetAllAsync(cancelToken))
                .Include(t => t.SubTypes)
                .ThenInclude(t => t!.SubTypes);

            return instTypes
                .Select(t => _mapper.Map<InstrumentTypeInfoResponse>(t))
                .AsQueryable();
        }
        ///<inheritdoc/>
        public async Task<InstrumentTypeInfoResponse> GetByIdAsync(Guid instTypeId, CancellationToken cancelToken = default)
        {
            var foundInstType = (await _instTypeRepository.GetAllAsync())
                .Include(t => t.SubTypes)
                .ThenInclude(t => t!.SubTypes)
                .First(u => u.Id == instTypeId);


            return _mapper.Map<InstrumentTypeInfoResponse>(foundInstType);
        }
    }
}
