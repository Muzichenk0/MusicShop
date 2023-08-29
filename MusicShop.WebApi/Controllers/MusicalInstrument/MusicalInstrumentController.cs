using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.MusicalInstrument.Services;
using MusicShop.Contracts.MusicalInstrument;
using System.Net;

namespace MusicShop.WebApi.Controllers.MusicalInstrument
{
    /// <summary>
    /// Модель - контроллер, определяющая интерфейс, с поведением из конечных точек, для обработки входящих запросов, нацеленных на сущность - музыкальный инструмент.
    /// </summary>
    [ApiController]
    public class MusicalInstrumentController : ControllerBase
    {
        /// <summary>
        /// Экземпляр для конкретной сущности из зависимости с абстрактным типом <see cref="IMusicalInstrumentService"></see>
        /// </summary>
        private readonly IMusicalInstrumentService _musInstrumentService;
        /// <summary>
        /// Экземпляр для конкретной сущности из зависимости с абстрактным типом <see cref="ILogger"></see>
        /// </summary>
        private readonly ILogger<MusicalInstrumentController> _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="musInstrumentService"></param>
        /// <param name="logger"></param>
        public MusicalInstrumentController(IMusicalInstrumentService musInstrumentService, ILogger<MusicalInstrumentController> logger)
        {
            _musInstrumentService = musInstrumentService;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_musInstrumentToAdd"></param>
        /// <param name="token"></param>
        [HttpPost("/creatingMusicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateMusicInstrumentAsync([FromBody]CreateMusicalInstrumentRequest musInstrumentToAdd, CancellationToken token = default)
        {
            await _musInstrumentService.AddMusicInstrumentAsync(musInstrumentToAdd, token);
            return Created("/creatingMusicalInstrument", musInstrumentToAdd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/musicalInstruments")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMusicInstrumentsAsync(CancellationToken token = default)
        {
            IQueryable<MusicalInstrumentResponseInfo> musInstruments = await _musInstrumentService.GetAllMusicInstrumentsAsync(token);
            return Ok(musInstruments);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="musicInstrument"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/musicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMusicInstrumentByIdAsync(Guid musicInstrument, CancellationToken token = default)
        {
            MusicalInstrumentResponseInfo musicInst = await _musInstrumentService.GetMusicInstrumentByIdAsync(musicInstrument, token);
            return Ok(musicInst);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="musicInstrumentToDelete"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("/deletingMusicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletingMusicInstrumentAsync([FromBody]DeleteMusicalInstrumentRequest musicInstrumentToDelete, CancellationToken token = default)
        {
            await _musInstrumentService.DeleteMusicInstrumentAsync(musicInstrumentToDelete,token);
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="musicInstrumentId"></param>
        /// <param name="musicInstrumentToUpdate"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("/updatingMusicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatingMusicInstrumentAsync(Guid musicInstrumentId,[FromBody]UpdateMusicalInstrumentRequest musicInstrumentToUpdate, CancellationToken token = default)
        {
            await _musInstrumentService.UpdateMusicInstrumentAsync(musicInstrumentId,musicInstrumentToUpdate, token);
            return Ok();
        }
        
    }
}
