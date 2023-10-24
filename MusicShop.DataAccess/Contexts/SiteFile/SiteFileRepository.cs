using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicShop.AppData.Contexts.SiteFile.Repository;
using MusicShop.Contracts.File;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.DataAccess.Contexts.SiteFile
{
    /// <summary>
    /// Конкретный ссылочный тип, реализующий <see cref="ISiteFileRepository"/>.
    /// Сервис, предоставляющая интерфейс для выполнения обязанностей модели - репозитория файла сайта
    /// </summary>
    public class SiteFileRepository : ISiteFileRepository
    {
        private readonly IRepository<Domain.Models.File.SiteFile> _siteFileRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public SiteFileRepository(
            IRepository<Domain.Models.File.SiteFile> siteFileRepository,
            ILogger<Domain.Models.File.SiteFile> logger,
            IMapper mapper)
        {
            _siteFileRepository = siteFileRepository;
            _logger = logger;
            _mapper = mapper;
        }
        ///<inheritdoc/>
        public async Task<IQueryable<SiteFileInfoResponse?>> GetAllFilesAsync(CancellationToken cancelToken = default)
        {
            var siteFilesQuery = (await _siteFileRepository.GetAllAsync(cancelToken))
                .Include(f => f.FileOffer);

            return siteFilesQuery.Select(file => _mapper.Map<SiteFileInfoResponse>(file));
        }
        ///<inheritdoc/>
        public async Task<SiteFileInfoResponse?> GetFileByIdAsync(Guid fileId, CancellationToken cancelToken = default)
        {
            var siteFiles = (await _siteFileRepository.GetAllAsync(cancelToken))
                .Include(f => f.FileOffer);

            return _mapper.Map<SiteFileInfoResponse>((await _siteFileRepository.GetByIdAsync(fileId, cancelToken)));
        }
        ///<inheritdoc/>
        public async Task<Guid> CreateFileAsync(CreateSiteFileRequest fileToCreate, CancellationToken cancelToken = default)
        {
            var fileToAdd = _mapper.Map<Domain.Models.File.SiteFile>(fileToCreate);
            await _siteFileRepository.AddAsync(fileToAdd, cancelToken);
            
            return fileToAdd.Id;
        }
        ///<inheritdoc/>
        public Task DeleteFileAsync(DeleteSiteFileRequest fileToDelete, CancellationToken cancelToken = default)
        {
            return _siteFileRepository.DeleteAsync(_mapper.Map<Domain.Models.File.SiteFile>(fileToDelete));
        }
        ///<inheritdoc/>
        public async Task UpdateFileAsync(Guid fileId, UpdateSiteFileRequest fileToUpdate, CancellationToken cancelToken = default)
        {
            var foundFile = await _siteFileRepository.GetByIdAsync(fileId, cancelToken);

            await _siteFileRepository.UpdateAsync(_mapper.Map(fileToUpdate, foundFile), cancelToken);
        }
    }
}
