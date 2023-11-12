using MusicShop.AppData.Contexts.InstrumentType.Repository;
using MusicShop.Contracts.InstrumentType;

namespace MusicShop.AppData.Contexts.InstrumentType.Services
{
    /// <summary>
    /// Конкретный ссылочный тип, реализующий интерфейс для сущности - сервис типа инструмента.
    /// </summary>
    public sealed class InstrumentTypeService : IInstrumentTypeService
    {
        /// <summary>
        /// Конкретный репозиторий, связанный с моделью - тип инструмента.
        /// </summary>
        private readonly IInstrumentTypeRepository _instTypeRepository;
        public InstrumentTypeService(IInstrumentTypeRepository instTypeRepository)
            => _instTypeRepository = instTypeRepository;
        ///<inheritdoc/>
        public Task AddInstrumentTypeAsync(CreateInstrumentTypeRequest instTypeToAdd, CancellationToken cancelToken = default)
            => _instTypeRepository.AddAsync(instTypeToAdd, cancelToken);
        ///<inheritdoc/>
        public Task DeleteInstrumentTypeAsync(DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken cancelToken = default)
            => _instTypeRepository.DeleteAsync(instTypeToDelete, cancelToken);
        ///<inheritdoc/>
        public Task<IQueryable<InstrumentTypeInfoResponse>> GetAllInstrumentTypesAsync(CancellationToken cancelToken = default)
            => _instTypeRepository.GetAllAsync(cancelToken);
        ///<inheritdoc/>
        public Task<InstrumentTypeInfoResponse> GetInstrumentTypeByIdAsync(Guid instTypeId, CancellationToken cancelToken = default)
            => _instTypeRepository.GetByIdAsync(instTypeId, cancelToken);
        ///<inheritdoc/>
        public Task UpdateInstrumentTypeAsync(Guid instTypeId, UpdateInstrumentTypeRequest instTypeToUpdate, CancellationToken cancelToken = default)
            => _instTypeRepository.UpdateAsync(instTypeId, instTypeToUpdate, cancelToken);
    }
}
