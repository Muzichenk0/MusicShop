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
        /// Конструктор сущности<see cref="MusicalInstrumentController"/>
        /// </summary>
        /// <param name="musInstrumentService">Сервис музыкального инструмента, взятый из зависимости</param>
        /// <param name="logger">Механизм для логгирования</param>
        /// <returns><see cref="IActionResult"/></returns>
        public MusicalInstrumentController(IMusicalInstrumentService musInstrumentService, ILogger<MusicalInstrumentController> logger)
        {
            _musInstrumentService = musInstrumentService;
            _logger = logger;
        }
        /// <summary>
        /// Создание музыкального инструмента, асинхронно.
        /// </summary>
        /// <param name="musInstrumentToAdd"></param>
        /// <param name="token">Жетон отмены асинхронной операции</param>   
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPost("/creatingMusicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateMusicInstrumentAsync([FromBody]CreateMusicalInstrumentRequest musInstrumentToAdd, CancellationToken token = default)
        {
            await _musInstrumentService.AddMusicInstrumentAsync(musInstrumentToAdd, token);
            return Created("/creatingMusicalInstrument", musInstrumentToAdd);
        }
        /// <summary>
        /// Получение всех музыкальных инструментов, асинхронно.
        /// </summary>
        /// <param name="token"></param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("/musicalInstruments")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMusicInstrumentsAsync(CancellationToken token = default)
        {
            IQueryable<MusicalInstrumentResponseInfo> musInstruments = await _musInstrumentService.GetAllMusicInstrumentsAsync(token);
            return Ok(musInstruments);
        }
        /// <summary>
        /// Получение музыкального инструмента, чей ID согласован с <paramref name="musicInstrumentId"/>, асинхронно.
        /// </summary>
        /// <param name="musicInstrumentId"></param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("/musicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMusicInstrumentByIdAsync([FromQuery]Guid musicInstrumentId, CancellationToken token = default)
        {
            MusicalInstrumentResponseInfo musicInst = await _musInstrumentService.GetMusicInstrumentByIdAsync(musicInstrumentId, token);
            return Ok(musicInst);
        }
        /// <summary>
        /// Удаление музыкального инструмента, асинхронно.
        /// </summary>
        /// <param name="musicInstrumentToDelete"></param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete("/deletingMusicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletingMusicInstrumentAsync([FromQuery] DeleteMusicalInstrumentRequest musicInstrumentToDelete, CancellationToken token = default)
        {
            await _musInstrumentService.DeleteMusicInstrumentAsync(musicInstrumentToDelete, token);
            return Ok();
        }
        /// <summary>
        /// Обновление музыкального инструмента, асинхронно.
        /// </summary>
        /// <param name="musicInstrumentId"></param>
        /// <param name="musicInstrumentToUpdate"></param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPut("/updatingMusicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatingMusicInstrumentAsync([FromQuery] Guid musicInstrumentId,[FromBody]UpdateMusicalInstrumentRequest musicInstrumentToUpdate, 
            CancellationToken token = default)
        {
            await _musInstrumentService.UpdateMusicInstrumentAsync(musicInstrumentId,musicInstrumentToUpdate, token);
            return Ok();
        }
        
    }
}
