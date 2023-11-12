

namespace MusicShop.Contracts.File
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный запросу на создание файла.
    /// </summary>
    public sealed class CreateSiteFileRequest
    {
        /// <summary>
        /// Расширение файла 
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Содержимое, составляющее файла
        /// </summary>
        public byte[] Content { get; set; }
    }
}
