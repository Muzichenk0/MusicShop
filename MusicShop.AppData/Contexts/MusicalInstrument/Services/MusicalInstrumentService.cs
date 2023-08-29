using MusicShop.AppData.Contexts.MusicalInstrument.Repository;
using MusicShop.Contracts.MusicalInstrument;

namespace MusicShop.AppData.Contexts.MusicalInstrument.Services
{
    /// <summary>
    /// Конкретный ссылочный тип, реализующий интерфейс для сущности - сервис музыкального инструмента.
    /// </summary>
    public class MusicalInstrumentService : IMusicalInstrumentService
    {
        private readonly IMusicalInstrumentRepository _musInstrumentRepository;
        public MusicalInstrumentService(IMusicalInstrumentRepository musInstrumentRepository)
            => _musInstrumentRepository = musInstrumentRepository;

        public Task AddMusicInstrumentAsync(CreateMusicalInstrumentRequest musInstrumentToAdd, CancellationToken cancelToken = default)
            => _musInstrumentRepository.AddAsync(musInstrumentToAdd, cancelToken);

        public Task DeleteMusicInstrumentAsync(DeleteMusicalInstrumentRequest musInstrumentToDelete, CancellationToken cancelToken = default)
            => _musInstrumentRepository.DeleteAsync(musInstrumentToDelete, cancelToken);

        public Task<IQueryable<MusicalInstrumentResponseInfo>> GetAllMusicInstrumentsAsync(CancellationToken cancelToken = default)
            => _musInstrumentRepository.GetAllAsync(cancelToken);

        public Task<MusicalInstrumentResponseInfo> GetMusicInstrumentByIdAsync(Guid musInstrumentId, CancellationToken cancelToken = default)
            => _musInstrumentRepository.GetByIdAsync(musInstrumentId, cancelToken);

        public Task UpdateMusicInstrumentAsync(Guid musInstrumentId, UpdateMusicalInstrumentRequest musInstrumentToUpdate, CancellationToken cancelToken = default)
            => _musInstrumentRepository.UpdateAsync(musInstrumentId, musInstrumentToUpdate, cancelToken);
    }
}
