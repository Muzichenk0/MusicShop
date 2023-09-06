using MusicShop.AppData.Contexts.Offer.Repository;
using MusicShop.Contracts.Offer;

namespace MusicShop.AppData.Contexts.Offer.Services
{
    /// <summary>
    /// Конкретный тип, реализующий интерфейс для модели - сервис предложения.
    /// </summary>
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public Task AddOfferAsync(CreateOfferRequest offerToAdd, CancellationToken cancelToken = default)
            => _offerRepository.AddAsync(offerToAdd, cancelToken);

        public Task DeleteOfferAsync(DeleteOfferRequest offerToDelete, CancellationToken cancelToken = default)
            => _offerRepository.DeleteAsync(offerToDelete, cancelToken);

        public Task<IQueryable<OfferInfoResponse>> GetAllOffersAsync(CancellationToken cancelToken = default)
            => _offerRepository.GetAllAsync(cancelToken);

        public Task<OfferInfoResponse> GetOfferByIdAsync(Guid offerId, CancellationToken cancelToken = default)
            => _offerRepository.GetByIdAsync(offerId, cancelToken);

        public Task UpdateOfferAsync(Guid offerId, UpdateOfferRequest offerToUpdate, CancellationToken cancelToken = default)
            => _offerRepository.UpdateAsync(offerId, offerToUpdate, cancelToken);
    }
}
