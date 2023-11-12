namespace MusicShop.Contracts.File
{
    /// <summary>
    /// Модель, определяющая интерфейс, доступный для запроса на удаление существующего файла
    /// </summary>
    public sealed class DeleteSiteFileRequest
    {
        /// <summary>
        /// Идентификатор файла сайта.
        /// </summary>
        public Guid? Id { get; set; }
    }
}
