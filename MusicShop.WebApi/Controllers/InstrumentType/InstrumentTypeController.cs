using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.InstrumentType.Services;
using MusicShop.Contracts.InstrumentType;
using System.Net;

namespace MusicShop.WebApi.Controllers.InstrumentType
{
    /// <summary>
    /// Модель - контроллер, определяющая интерфейс, с поведением из конечных точек, для обработки входящих запросов, нацеленных на сущность - тип инструмента.
    /// </summary>
    [ApiController]
    [Route("instrumentType")]
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
        [HttpPost()]
        [ProducesResponseType(typeof(CreateInstrumentTypeRequest),(int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateInstrumentTypeAsync([FromBody] CreateInstrumentTypeRequest instTypeToAdd, CancellationToken token = default)
        {
            await _instTypeService.AddInstrumentTypeAsync(instTypeToAdd, token);

            return Created("/instrumentType", instTypeToAdd);
        }
        /// <summary>
        /// Получение всех типов инструментов, асинхронно.
        /// </summary>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        [HttpGet("instrumentTypes")]
        [ProducesResponseType(typeof(IQueryable<InstrumentTypeInfoResponse>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllInstrumentTypesAsync(CancellationToken token = default)
        {
            IQueryable<InstrumentTypeInfoResponse> instTypes = await _instTypeService.GetAllInstrumentTypesAsync(token);

            return Ok(instTypes);
        }
        /// <summary>
        /// Получение типа инструмента, чей ID, согласован с <paramref name="instTypeId"/>, асинхронно.
        /// </summary>
        /// <param name="instTypeId">Идентификатор типа инструмента</param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        [HttpGet("{instTypeId:guid}")]
        [ProducesResponseType(typeof(InstrumentTypeInfoResponse),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetInstrumentTypeByIdAsync([FromQuery] Guid instTypeId, CancellationToken token = default)
        {
            InstrumentTypeInfoResponse instTypes = await _instTypeService.GetInstrumentTypeByIdAsync(instTypeId, token);

            return Ok(instTypes);
        }
        /// <summary>
        /// Удаление типа инструмента, асинхронно.
        /// </summary>
        /// <param name="instTypeToDelete">Тип инструмента для удаления</param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        [HttpDelete()]
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
        /// <param name="updateInfo">Тип инструмента для удаления</param>
        /// <param name="token">Жетон отмены асинхронной операции</param>
        [HttpPut("{instTypeId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateInstrumentTypeAsync(Guid instTypeId, [FromBody]UpdateInstrumentTypeRequest updateInfo,
            CancellationToken token = default)
        {
            await _instTypeService.UpdateInstrumentTypeAsync(instTypeId, updateInfo, token);
            return Ok();
        }
    }
}
