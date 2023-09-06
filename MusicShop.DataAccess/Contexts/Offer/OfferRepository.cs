using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.Offer.Repository;
using MusicShop.Contracts.Offer;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.DataAccess.Contexts.Offer
{
    /// <summary>
    /// Модель, реализующая внешний интерфейс для модели - репозиторий предложения, описанный в  <see cref="IOfferRepository"/>.
    /// </summary>
    public class OfferRepository : IOfferRepository
    {
        private readonly IRepository<Domain.Models.Offer.Offer> _offerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OfferRepository> _logger;
        public OfferRepository(IRepository<Domain.Models.Offer.Offer> offerRepository, IMapper mapper, ILogger<OfferRepository> logger)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public Task AddAsync(CreateOfferRequest offerToAdd, CancellationToken cancelToken = default)
        {
            return _offerRepository.AddAsync(_mapper.Map<Domain.Models.Offer.Offer>(offerToAdd), cancelToken);
        }

        public Task DeleteAsync(DeleteOfferRequest offerToDelete, CancellationToken cancelToken = default)
        {
            return _offerRepository.DeleteAsync(_mapper.Map<Domain.Models.Offer.Offer>(offerToDelete), cancelToken);
        }

        public async Task<IQueryable<OfferInfoResponse>> GetAllAsync(CancellationToken cancelToken = default)
        {
            var offers = (await _offerRepository.GetAllAsync(cancelToken))
                .Include(o => o.User)
                .Include(o => o.ClosedUser);

            return offers
                .Select(o => _mapper.Map<OfferInfoResponse>(o))
                .AsQueryable();
        }

        public async Task<OfferInfoResponse> GetByIdAsync(Guid id, CancellationToken cancelToken = default)
        {
            var foundOffer = (await _offerRepository.GetAllAsync(cancelToken))
                .Include(o => o.User)
                .Include(o => o.ClosedUser)
                .First(o => o.Id == id);

            return _mapper.Map<OfferInfoResponse>(foundOffer);
        }

        public async Task UpdateAsync(Guid offerId, UpdateOfferRequest offerToUpdate, CancellationToken cancelToken = default)
        {
            var foundOffer = await _offerRepository.GetByIdAsync(offerId, cancelToken);

            await _offerRepository
                .UpdateAsync(_mapper.Map(offerToUpdate, foundOffer), cancelToken);
        }
    }
}
