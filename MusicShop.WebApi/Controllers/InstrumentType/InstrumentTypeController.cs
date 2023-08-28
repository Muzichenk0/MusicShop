using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.MusicalInstrument.InstrumentType.Services;
using MusicShop.Contracts.InstrumentType;
using System.Net;

namespace MusicShop.WebApi.Controllers.InstrumentType
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class InstrumentTypeController : ControllerBase
    {
        private readonly IInstrumentTypeService _instTypeService;
        private readonly ILogger<InstrumentTypeController> _logger;
        public InstrumentTypeController(IInstrumentTypeService instTypeService, ILogger<InstrumentTypeController> logger)
        {
            _instTypeService = instTypeService;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instTypeToAdd"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("/creatingInstrumentType")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateInstrumentTypeAsync([FromBody]CreateInstrumentTypeRequest instTypeToAdd, CancellationToken token = default)
        {
            await _instTypeService.AddInstrumentTypeAsync(instTypeToAdd, token);

            return Created("/creatingInstrumentType", instTypeToAdd);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/instrumentTypes")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllInstrumentTypesAsync(CancellationToken token = default)
        {
            IQueryable<InstrumentTypeResponseInfo> instTypes = await _instTypeService.GetAllInstrumentTypesAsync(token);

            return Ok(instTypes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instTypeId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/instrumentType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetInstrumentByIdAsync([FromHeader]Guid instTypeId, CancellationToken token = default)
        {
            InstrumentTypeResponseInfo instTypes = await _instTypeService.GetInstrumentTypeByIdAsync(instTypeId, token);

            return Ok(instTypes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instTypeToDelete"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("/deletingInstrumentType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteInstrumentTypeAsync([FromBody]DeleteInstrumentTypeRequest instTypeToDelete, CancellationToken token = default)
        {
            await _instTypeService.DeleteInstrumentTypeAsync(instTypeToDelete, token);
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instTypeId"></param>
        /// <param name="instTypeToUpdate"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut("/updatingInstrumentType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateInstrumentTypeAsync([FromHeader]Guid instTypeId, UpdateInstrumentTypeRequest instTypeToUpdate, CancellationToken token = default)
        {
            await _instTypeService.UpdateInstrumentTypeAsync(instTypeId, instTypeToUpdate, token);
            return Ok();
        }



    }
}
