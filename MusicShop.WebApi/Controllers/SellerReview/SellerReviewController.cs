using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.SellerReview.Services;
using MusicShop.Contracts.SellerReview;
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
        /// 
        /// </summary>
        /// <param name="sReviewToAdd"></param>
        /// <param name="token"></param>
        [HttpPost("/creatingSellerReview")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateSellerReviewAsync([FromBody] CreateSellerReviewRequest sReviewToAdd, CancellationToken token = default)
        {
            await _sReviewService.CreateReviewAsync(sReviewToAdd, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToAdd)} was added into database");

            return Created("/creatingSellerReview", sReviewToAdd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/sellerReviews")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllSellerReviewsAsync(CancellationToken token = default)
        {
            IQueryable<SellerReviewResponseInfo> sReviews = await _sReviewService.GetAllReviewsAsync(token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviews)} were taken from database");

            return Ok(sReviews);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sReviewId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/sellerReview")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetSellerReviewByIdAsync(Guid sReviewId, CancellationToken token = default)
        {
            SellerReviewResponseInfo sReview = await _sReviewService.GetReviewByIdAsync(sReviewId, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReview)} was taken from database");

            return Ok(sReview);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sReviewToDelete"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("/deletingSellerReview")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSellerReviewAsync([FromBody]DeleteSellerReviewRequest sReviewToDelete, CancellationToken token = default)
        {
            await _sReviewService.DeleteReviewAsync(sReviewToDelete, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewToDelete)} was deleted from database");

            return Ok();
        }
        [HttpPut("/updatingSellerReview")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateSellerReviewAsync(Guid sReviewId, [FromBody] UpdateSellerReviewRequest sReviewToUpdate, CancellationToken token = default)
        {
            await _sReviewService.UpdateReviewAsync(sReviewId, sReviewToUpdate, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(sReviewId)} was updated into database");

            return Ok();
        }
    }
}
