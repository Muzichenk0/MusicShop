namespace MusicShop.Contracts.File
{
    /// <summary>
    /// Модель, доступная
    /// </summary>
    public sealed class UpdateSiteFileRequest
    {
        /// <summary>
        /// Идентификатор файла сайта
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Содержимое, составляющее файла
        /// </summary>
        public byte[] Content { get; set; }
    }
}
