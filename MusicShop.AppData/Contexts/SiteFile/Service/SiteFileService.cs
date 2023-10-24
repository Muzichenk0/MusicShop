
using Microsoft.AspNetCore.Http;
using MusicShop.AppData.Contexts.SiteFile.Repository;
using MusicShop.Contracts.File;

namespace MusicShop.AppData.Contexts.SiteFile.Service
{
    /// <summary>
    /// Конкретная реализация <see cref="ISiteFileService"/>.
    /// Модель сервиса файла сайта
    /// </summary>
    public sealed class SiteFileService : ISiteFileService
    {
        private readonly ISiteFileRepository _siteFileRepository;
        public SiteFileService(ISiteFileRepository siteFileRepository)
        {
            _siteFileRepository = siteFileRepository;
        }
        ///<inheritdoc/>
        public Task<Guid> CreateFileAsync(CreateSiteFileRequest fileToCreate, CancellationToken cancelToken = default)
        {
            return _siteFileRepository.CreateFileAsync(fileToCreate, cancelToken);
        }
        ///<inheritdoc/>
        public Task DeleteFileAsync(DeleteSiteFileRequest fileToDelete, CancellationToken cancelToken = default)
        {
            return _siteFileRepository.DeleteFileAsync(fileToDelete, cancelToken);
        }
        ///<inheritdoc/>
        public Task<IQueryable<SiteFileInfoResponse?>> GetAllFilesAsync(CancellationToken cancelToken = default)
        {
            return _siteFileRepository.GetAllFilesAsync(cancelToken);
        }
        ///<inheritdoc/>
        public Task<SiteFileInfoResponse?> GetFileByIdAsync(Guid fileId, CancellationToken cancelToken = default)
        {
            return _siteFileRepository.GetFileByIdAsync(fileId, cancelToken);
        }
        ///<inheritdoc/>
        public Task UpdateFileAsync(Guid fileId, UpdateSiteFileRequest fileToUpdate, CancellationToken cancelToken = default)
        {
            return _siteFileRepository.UpdateFileAsync(fileId, fileToUpdate, cancelToken);
        }
        ///<inheritdoc/>
        public async Task<byte[]> GetBytesFromFileAsync(IFormFile file)
        {
            using MemoryStream mStream = new MemoryStream();
            await file.CopyToAsync(mStream);
            return mStream.ToArray();
        }
        ///<inheritdoc/>
        public string GetFormFileExtension(IFormFile file)
        {
            return file.ContentType.Split('/')[1];
        }
    }
}
