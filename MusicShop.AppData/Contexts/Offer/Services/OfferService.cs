using MusicShop.AppData.Contexts.Offer.Repository;
using MusicShop.Contracts.Offer;

namespace MusicShop.AppData.Contexts.Offer.Services
{
    /// <summary>
    /// Конкретный тип, реализующий интерфейс для модели - сервис предложения.
    /// </summary>
    public sealed class OfferService : IOfferService
    {
        /// <summary>
        /// Конкретный репозиторий, связанный с моделью - предложение.
        /// </summary>
        private readonly IOfferRepository _offerRepository;
        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        ///<inheritdoc/>
        public Task AddOfferAsync(CreateOfferRequest offerToAdd, CancellationToken cancelToken = default)
            => _offerRepository.AddAsync(offerToAdd, cancelToken);
        ///<inheritdoc/>
        public Task DeleteOfferAsync(DeleteOfferRequest offerToDelete, CancellationToken cancelToken = default)
            => _offerRepository.DeleteAsync(offerToDelete, cancelToken);
        ///<inheritdoc/>
        public Task<IQueryable<OfferInfoResponse>> GetAllOffersAsync(CancellationToken cancelToken = default)
            => _offerRepository.GetAllAsync(cancelToken);
        ///<inheritdoc/>
        public Task<OfferInfoResponse> GetOfferByIdAsync(Guid offerId, CancellationToken cancelToken = default)
            => _offerRepository.GetByIdAsync(offerId, cancelToken);
        ///<inheritdoc/>
        public Task UpdateOfferAsync(Guid offerId, UpdateOfferRequest offerToUpdate, CancellationToken cancelToken = default)
            => _offerRepository.UpdateAsync(offerId, offerToUpdate, cancelToken);
    }
}
