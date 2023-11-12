using MusicShop.Domain.Models.Base;

namespace MusicShop.Domain.Models.File
{
    /// <summary>
    /// Доменная модель сайта файла.
    /// Зависима и реализует <see cref="BaseEntity"/>
    /// </summary>
    public sealed class SiteFile : BaseEntity
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
        /// <summary>
        /// Уникальный идентификатор предложения
        /// Внешний ключ в отношении один ко многим между глав. сущностью <see cref="Offer.Offer"/> и зависимой <see cref="SiteFile"/>
        /// </summary>
        public Guid? OfferId { get; set; }
        /// <summary>
        /// Навигационное в отношении один ко многим между глав. сущностью <see cref="Offer.Offer"/> и зависимой <see cref="SiteFile"/>
        /// </summary>
        public Offer.Offer FileOffer { get; set; }
    }
}
