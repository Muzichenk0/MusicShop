using MusicShop.AppData.Contexts.InstrumentType.Repository;
using MusicShop.Contracts.InstrumentType;

namespace MusicShop.AppData.Contexts.InstrumentType.Services
{
    /// <summary>
    /// Конкретный ссылочный тип, реализующий интерфейс для сущности - сервис типа инструмента.
    /// </summary>
    public class InstrumentTypeService : IInstrumentTypeService
    {
        private readonly IInstrumentTypeRepository _instTypeRepository;
        public InstrumentTypeService(IInstrumentTypeRepository instTypeRepository)
            => _instTypeRepository = instTypeRepository;
        public Task AddInstrumentTypeAsync(CreateInstrumentTypeRequest instTypeToAdd, CancellationToken cancelToken = default)
            => _instTypeRepository.AddAsync(instTypeToAdd, cancelToken);

        public Task DeleteInstrumentTypeAsync(DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken cancelToken = default)
            => _instTypeRepository.DeleteAsync(instTypeToDelete, cancelToken);

        public Task<IQueryable<InstrumentTypeInfoResponse>> GetAllInstrumentTypesAsync(CancellationToken cancelToken = default)
            => _instTypeRepository.GetAllAsync(cancelToken);

        public Task<InstrumentTypeInfoResponse> GetInstrumentTypeByIdAsync(Guid instTypeId, CancellationToken cancelToken = default)
            => _instTypeRepository.GetByIdAsync(instTypeId, cancelToken);

        public Task UpdateInstrumentTypeAsync(Guid instTypeId, UpdateInstrumentTypeRequest instTypeToUpdate, CancellationToken cancelToken = default)
            => _instTypeRepository.UpdateAsync(instTypeId, instTypeToUpdate, cancelToken);
    }
}
