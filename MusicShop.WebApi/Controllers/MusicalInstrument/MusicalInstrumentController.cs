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
        /// <returns></returns>
        [HttpPost("/creatingMusicalInstrument")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateMusicInstrumentAsync([FromBody]CreateMusicalInstrumentRequest _musInstrumentToAdd, CancellationToken token = default)
        {
            await _musInstrumentService.AddMusicInstrumentAsync(_musInstrumentToAdd, token);
            return Created("/creatingMusicalInstrument", _musInstrumentToAdd);
        }
    }
}
