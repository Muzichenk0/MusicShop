using MusicShop.AppData.Contexts.MusicalInstrument.InstrumentType.Repository;
using MusicShop.Contracts.InstrumentType;

namespace MusicShop.AppData.Contexts.MusicalInstrument.InstrumentType.Services
{
    public class InstrumentTypeService : IInstrumentTypeService
    {
        private readonly IInstrumentTypeRepository _instTypeRepository;
        public InstrumentTypeService(IInstrumentTypeRepository instTypeRepository)
            => _instTypeRepository = instTypeRepository;
        public async Task AddInstrumentTypeAsync(CreateInstrumentTypeRequest instTypeToAdd, CancellationToken cancelToken = default)
            => await _instTypeRepository.AddAsync(instTypeToAdd, cancelToken);
        
        public async Task DeleteInstrumentTypeAsync(DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken cancelToken = default)
            => await _instTypeRepository.DeleteAsync(instTypeToDelete, cancelToken);

        public async Task<IQueryable<InstrumentTypeResponseInfo>> GetAllInstrumentTypesAsync(CancellationToken cancelToken = default)
            => await _instTypeRepository.GetAllAsync(cancelToken);

        public async Task<InstrumentTypeResponseInfo> GetInstrumentTypeByIdAsync(Guid instTypeId, CancellationToken cancelToken = default)
            => await _instTypeRepository.GetByIdAsync(instTypeId, cancelToken);

        public async Task UpdateInstrumentTypeAsync(Guid instTypeId, UpdateInstrumentTypeRequest instTypeToUpdate, CancellationToken cancelToken = default)
            => await _instTypeRepository.UpdateAsync(instTypeId, instTypeToUpdate, cancelToken);
    }
}
