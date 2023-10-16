
namespace MusicShop.AppData.Contexts.SiteFile
{
    public interface ISiteFileService
    {
        public Task GetAllFilesAsync(CancellationToken token = default);
    }
}
