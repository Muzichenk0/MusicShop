using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.Offer.Services;
using MusicShop.Contracts.Offer;
using System.Net;

namespace MusicShop.WebApi.Controllers.Offer
{
    /// <summary>
    /// Модель - контроллер, определяющая интерфейс, с поведением из конечных точек, для обработки входящих запросов, нацеленных на сущность - предложение.
    /// </summary>
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly ILogger<OfferController> _logger;
        public OfferController(IOfferService service, ILogger<OfferController> logger)
        {
            _offerService = service;
            _logger = logger;
        }
        /// <summary>
        /// Создание нового предложения, асинхронно.
        /// </summary>
        /// <param name="offerToAdd">Предложение для создания</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpPost("/creatingOffer")]
        [ProducesResponseType(typeof(CreateOfferRequest),(int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOfferAsync([FromBody]CreateOfferRequest offerToAdd, CancellationToken token = default)
        {
            await _offerService.AddOfferAsync(offerToAdd, token) ;
            return Created("/creatingOffer",offerToAdd);
        }
        /// <summary>
        /// Получение всех предложений, асинхронно.
        /// </summary>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpGet("/offers")]
        [ProducesResponseType(typeof(IQueryable<OfferInfoResponse>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllOfferAsync(CancellationToken token = default)
        {
            IQueryable<OfferInfoResponse> offers = await _offerService.GetAllOffersAsync(token);
            return Ok(offers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/offer/{offerId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetOfferByIdAsync(Guid offerId, CancellationToken token = default)
        {
            OfferInfoResponse offer = await _offerService.GetOfferByIdAsync(offerId, token);
            return Ok(offer);
        }

    }
}
