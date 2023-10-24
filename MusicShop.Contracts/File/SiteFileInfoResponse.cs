using MusicShop.Contracts.Offer;

namespace MusicShop.Contracts.File
{
    /// <summary>
    /// Модель, определяющая интерфейс 
    /// </summary>
    public sealed class SiteFileInfoResponse
    {
        /// <summary>
        /// Уникальный идентификатор файла сайта
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Расширение файла сайта
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Псевдоним файла сайта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Содержмиое, составляющее сайта файла
        /// </summary>
        public byte[] Content { get; set; }
        /// <summary>
        /// Предложение, частью которого является текущий файл.
        /// </summary>
        public OfferInfoResponse FileOffer { get; set; }
    }
}
