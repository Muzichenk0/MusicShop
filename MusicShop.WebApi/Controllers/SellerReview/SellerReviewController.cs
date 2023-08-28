using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.SellerReview.Services;
using MusicShop.Contracts.SellerReview;
using MusicShop.Contracts.User;
using System.Net;
using System.Text.Json;

namespace MusicShop.WebApi.Controllers.SellerReview
{
    [ApiController]
    public sealed class SellerReviewController : ControllerBase
    {
        private readonly ILogger<SellerReviewController> _logger;
        private readonly ISellerReviewService _sReviewService;
        public SellerReviewController(ILogger<SellerReviewController> logger, ISellerReviewService sellerReviewService)
        {
            _logger = logger;
            _sReviewService = sellerReviewService;
        }
        /// <summary>
        /// Добавление нового отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewToAdd">Информация об отзыве о продавце, для добавления.</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPost("/creatingSellerReview")]
        [ProducesResponseType(typeof(CreateSellerReviewRequest),(int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSellerReviewAsync([FromBody] CreateSellerReviewRequest sReviewToAdd, CancellationToken token = default)
        {
            await _sReviewService.CreateReviewAsync(sReviewToAdd, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToAdd)} was added into database");

            return Created("/creatingSellerReview", sReviewToAdd);
        }
        /// <summary>
        /// Получение всех отзывов о продавцах, асинхронно.
        /// </summary>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("/sellerReviews")]
        [ProducesResponseType(typeof(IQueryable<SellerReviewResponseInfo>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllSellerReviewsAsync(CancellationToken token = default)
        {
            IQueryable<SellerReviewResponseInfo> sReviews = await _sReviewService.GetAllReviewsAsync(token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviews)} were taken from database");

            return Ok(sReviews);
        }
        /// <summary>
        /// Получение отзыва о продавце, чей ID согласован с <paramref name="sReviewId"/>, асинхронно.
        /// </summary>
        /// <param name="sReviewId">Идентификатор отзыва о продавце</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("/sellerReview")]
        [ProducesResponseType(typeof(SellerReviewResponseInfo),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSellerReviewByIdAsync(Guid sReviewId, CancellationToken token = default)
        {
            SellerReviewResponseInfo sReview = await _sReviewService.GetReviewByIdAsync(sReviewId, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReview)} was taken from database");

            return Ok(sReview);
        }
        /// <summary>
        /// Удаление отзыва о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewToDelete">Информация об отзыве о продавце, для удаления</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete("/deletingSellerReview")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteSellerReviewAsync([FromBody]DeleteSellerReviewRequest sReviewToDelete, CancellationToken token = default)
        {
            await _sReviewService.DeleteReviewAsync(sReviewToDelete, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToDelete)} was deleted from database");

            return Ok();
        }
        /// <summary>
        /// Обновление информации об отзыве о продавце, асинхронно.
        /// </summary>
        /// <param name="sReviewId">Идентификатор отзыва о продавце</param>
        /// <param name="sReviewToUpdate">Новая информация об отзыве о продавце</param>
        /// <param name="token">Жетон для отмены асинхронной задачи</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPut("/updatingSellerReview")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateSellerReviewAsync(Guid sReviewId, [FromBody] UpdateSellerReviewRequest sReviewToUpdate, CancellationToken token = default)
        {
            await _sReviewService.UpdateReviewAsync(sReviewId, sReviewToUpdate, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewId)} was updated into database");

            return Ok();
        }
    }
}
