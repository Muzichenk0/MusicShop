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
    [Route("offer")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly ILogger<OfferController> _logger;
        /// <summary>
        /// Конструктор для экземпляра сущности <see cref="OfferController"/>
        /// </summary>
        /// <param name="service">Экземпляр сервиса для модели предложения. Берется из зависимости</param>
        /// <param name="logger">Механизм логгирования информации.</param>
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
        [HttpPost()]
        [ProducesResponseType(typeof(CreateOfferRequest),(int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOfferAsync([FromBody]CreateOfferRequest offerToAdd, CancellationToken token = default)
        {
            await _offerService.AddOfferAsync(offerToAdd, token) ;
            return Created("/offer",offerToAdd);
        }
        /// <summary>
        /// Получение всех предложений, асинхронно.
        /// </summary>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        [HttpGet("offers")]
        [ProducesResponseType(typeof(IQueryable<OfferInfoResponse>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllOfferAsync(CancellationToken token = default)
        {
            IQueryable<OfferInfoResponse> offers = await _offerService.GetAllOffersAsync(token);
            return Ok(offers);
        }
        /// <summary>
        /// Получение предложения с помощью идентификатора, асинхронно.
        /// </summary>
        /// <param name="offerId">Идентификатор предложения</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns></returns>
        [HttpGet("{offerId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetOfferByIdAsync(Guid offerId, CancellationToken token = default)
        {
            OfferInfoResponse offer = await _offerService.GetOfferByIdAsync(offerId, token);
            return Ok(offer);
        }
        /// <summary>
        /// Удаление существующего предложения, асинхронно.
        /// </summary>
        /// <param name="offerToDelete">Существующее предложение для удаления</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns></returns>
        [HttpDelete()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteOfferAsync([FromBody]DeleteOfferRequest offerToDelete, CancellationToken token = default)
        {
            await _offerService.DeleteOfferAsync(offerToDelete, token);
            return Ok();
        }
        /// <summary>
        /// Обновление информации у существующего предложения, асинхронно.
        /// </summary>
        /// <param name="offerId">Идентификатор предложения</param>
        /// <param name="updateInfo">Информация для изменения существующего предложения</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns></returns>
        [HttpPut("{offerId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateOfferAsync(Guid offerId, [FromBody] UpdateOfferRequest updateInfo, CancellationToken token = default)
        {
            await _offerService.UpdateOfferAsync(offerId, updateInfo, token);
            return Ok();
        }
    }
}
