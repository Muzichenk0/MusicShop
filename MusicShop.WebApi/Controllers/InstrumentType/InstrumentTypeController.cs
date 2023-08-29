using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.MusicalInstrument.InstrumentType.Services;
using MusicShop.Contracts.InstrumentType;
using System.Net;

namespace MusicShop.WebApi.Controllers.InstrumentType
{
    /// <summary>
    /// Модель - контроллер, определяющая интерфейс, с поведением из конечных точек, для обработки входящих запросов, нацеленных на сущность - тип инструмента.
    /// </summary>
    [ApiController]
    public class InstrumentTypeController : ControllerBase
    {
        /// <summary>
        /// Экземпляр для конкретной сущности из зависимости с абстрактным типом <see cref="IInstrumentTypeService"></see>
        /// </summary>
        private readonly IInstrumentTypeService _instTypeService;
        /// <summary>
        /// Экземпляр для конкретной сущности из зависимости с абстрактным типом <see cref="ILogger"></see>
        /// </summary>
        private readonly ILogger<InstrumentTypeController> _logger;
        /// <summary>
        /// Конструктор сущности <see cref="InstrumentTypeController"/>
        /// </summary>
        /// <param name="instTypeService">Сервис типа инструмента, взятый из зависимости</param>
        /// <param name="logger">Механизм логгирования</param>
        public InstrumentTypeController(IInstrumentTypeService instTypeService, ILogger<InstrumentTypeController> logger)
        {
            _instTypeService = instTypeService;
            _logger = logger;
        }
        /// <summary>
        /// Создание типа инструмента, асинхронно.
        /// </summary>
        /// <param name="instTypeToAdd">Тип инструмента для добавления</param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPost("/creatingInstrumentType")]
        [ProducesResponseType(typeof(CreateInstrumentTypeRequest),(int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateInstrumentTypeAsync([FromBody] CreateInstrumentTypeRequest instTypeToAdd, CancellationToken token = default)
        {
            await _instTypeService.AddInstrumentTypeAsync(instTypeToAdd, token);

            return Created("/creatingInstrumentType", instTypeToAdd);
        }
        /// <summary>
        /// Получение всех типов инструментов, асинхронно.
        /// </summary>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("/instrumentTypes")]
        [ProducesResponseType(typeof(IQueryable<InstrumentTypeResponseInfo>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllInstrumentTypesAsync(CancellationToken token = default)
        {
            IQueryable<InstrumentTypeResponseInfo> instTypes = await _instTypeService.GetAllInstrumentTypesAsync(token);

            return Ok(instTypes);
        }
        /// <summary>
        /// Получение типа инструмента, чей ID, согласован с <paramref name="instTypeId"/>, асинхронно.
        /// </summary>
        /// <param name="instTypeId">Идентификатор типа инструмента</param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("/instrumentType")]
        [ProducesResponseType(typeof(InstrumentTypeResponseInfo),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetInstrumentByIdAsync([FromQuery] Guid instTypeId, CancellationToken token = default)
        {
            InstrumentTypeResponseInfo instTypes = await _instTypeService.GetInstrumentTypeByIdAsync(instTypeId, token);

            return Ok(instTypes);
        }
        /// <summary>
        /// Удаление типа инструмента, асинхронно.
        /// </summary>
        /// <param name="instTypeToDelete">Тип инструмента для удаления</param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete("/deletingInstrumentType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteInstrumentTypeAsync([FromQuery] DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken token = default)
        {
            await _instTypeService.DeleteInstrumentTypeAsync(instTypeToDelete, token);
            return Ok();
        }
        /// <summary>
        /// Обновление типа инструмента, асинхронно.
        /// </summary>
        /// <param name="instTypeId">Идентификатор типа инструмента</param>
        /// <param name="instTypeToUpdate">Тип инструмента для удаления</param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpPut("/updatingInstrumentType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateInstrumentTypeAsync([FromQuery] Guid instTypeId, [FromBody]UpdateInstrumentTypeRequest instTypeToUpdate,
            CancellationToken token = default)
        {
            await _instTypeService.UpdateInstrumentTypeAsync(instTypeId, instTypeToUpdate, token);
            return Ok();
        }
    }
}
