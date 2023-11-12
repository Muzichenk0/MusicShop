using Microsoft.AspNetCore.Mvc;
using MusicShop.AppData.Contexts.SiteFile.Service;
using MusicShop.Contracts.File;
using System.Net;
using System.Text.Json;

namespace MusicShop.WebApi.Controllers.SiteFile
{
    /// <summary>
    /// Контроллер, хранящий конечные точки для обработки входящих запросов, связанных с доменной моделью - файл сайта/>
    /// </summary>
    [ApiController()]
    [Route("/siteFile")]
    public sealed class SiteFileController : ControllerBase
    {
        private readonly ISiteFileService _siteFileService;
        private readonly ILogger<SiteFileController> _logger;
        /// <summary>
        /// Конструктор, определяющий логику инициализации экземпляра <see cref="SiteFileController"/>
        /// </summary>
        /// <param name="siteFileService">экземпляр сервис файла сайта, извлеченный из зависимости</param>
        /// <param name="logger">логгер, экземпляр извлеченный из зависимости</param>
        public SiteFileController(ISiteFileService siteFileService, ILogger<SiteFileController> logger)
        {
            _siteFileService = siteFileService;
            _logger = logger;
        }
        /// <summary>
        /// Создание файла сайта, асинхронно
        /// </summary>
        /// <param name="file">Выбранный файл</param>
        /// <param name="token">Жетон отмены асинхронной задачи</param>
        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IResult> CreateSiteFileAsync(IFormFile file, CancellationToken token = default)
        {
            CreateSiteFileRequest siteFileToAdd = new CreateSiteFileRequest()
            {
                Content = await _siteFileService.GetBytesFromFileAsync(file),
                Extension =  _siteFileService.GetFormFileExtension(file),
                Name = file.Name
            };

            Guid fileId = await _siteFileService.CreateFileAsync(siteFileToAdd, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(siteFileToAdd.Name)} was added into database");

            return Results.Created("/file", fileId);
        }
        /// <summary>
        /// Получение всех файлов, асинхронно
        /// </summary>
        /// <param name="token">Жетон отмены асинхронной задачи</param>
        [HttpGet("all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IResult> GetAllSiteFilesAsync(CancellationToken token = default)
        {
            IQueryable<SiteFileInfoResponse?> siteFiles = await _siteFileService.GetAllFilesAsync(token);

            foreach (SiteFileInfoResponse file in siteFiles)
                _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(file)} was taken from database");

            return Results.Ok(siteFiles);
        }
        /// <summary>
        /// Получение информации о существующем файле, чей ID согласован с <paramref name="fileId"/>, асинхронно
        /// </summary>
        /// <param name="fileId">Идентификатор необходимого файла</param>
        /// <param name="token">Жетон отмены асинхронной задачи</param>
        [HttpGet("{fileId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IResult> GetSiteFileById([FromRoute] Guid fileId, CancellationToken token = default)
        {
            SiteFileInfoResponse? siteFile = await _siteFileService.GetFileByIdAsync(fileId, token);
            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(siteFile.Name)} was taken from database");
            return Results.Ok(siteFile);
        }
        /// <summary>
        /// Удаление существующего файла сайта, асинхронно
        /// </summary>
        /// <param name="fileToDelete">Информация о файле для удаления</param>
        /// <param name="token">Жетон отмены асинхронной задачи</param>
        [HttpDelete()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IResult> DeleteSiteFileAsync([FromQuery] DeleteSiteFileRequest fileToDelete, CancellationToken token = default)
        {
            await _siteFileService.DeleteFileAsync(fileToDelete, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(fileToDelete.Id)} was deleted from database");

            return Results.Ok();
        }
        /// <summary>
        /// Обновление существующего файла, новым, асинхронно
        /// </summary>
        /// <param name="fileId">Идентификатор существующего файла</param>
        /// <param name="newFile">Новый файл</param>
        /// <param name="token">Жетон отмены асинхронной задачи</param>
        [HttpPut("{fileId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IResult> UpdateSiteFileAsync([FromRoute]Guid fileId, IFormFile newFile, CancellationToken token = default)
        {
            UpdateSiteFileRequest fileToUpdate = new UpdateSiteFileRequest()
            {
                Id = fileId,
                Name = newFile.Name,
                Content = await _siteFileService.GetBytesFromFileAsync(newFile),
                Extension = _siteFileService.GetFormFileExtension(newFile)
            };
            await _siteFileService.UpdateFileAsync(fileId, fileToUpdate, token);

            _logger.Log(LogLevel.Information, $"{JsonSerializer.Serialize(fileId)} was updated in database");

            return Results.Ok();
        }
    }
}
