using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.AppData.Contexts.InstrumentType.Repository;
using MusicShop.AppData.Contexts.InstrumentType.Services;
using MusicShop.AppData.Contexts.Offer.Repository;
using MusicShop.AppData.Contexts.Offer.Services;
using MusicShop.AppData.Contexts.SellerReview.Repository;
using MusicShop.AppData.Contexts.SellerReview.Services;
using MusicShop.AppData.Contexts.SiteFile.Repository;
using MusicShop.AppData.Contexts.SiteFile.Service;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.AppData.Contexts.User.Services;
using MusicShop.DataAccess.Contexts.InstrumentType;
using MusicShop.DataAccess.Contexts.Offer;
using MusicShop.DataAccess.Contexts.SellerReview;
using MusicShop.DataAccess.Contexts.SiteFile;
using MusicShop.DataAccess.Contexts.User;
using MusicShop.DataAccess.Db;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.Registrator
{
    /// <summary>
    /// Ссылочный тип, хранящий методы доступа для <see cref="IServiceCollection"/>.
    /// Предоставляет метод для определения базовых настроек зависимостей из контекнера IOC.
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// Конфигурация и добавление зависимостей в DI, IOC контейнер.
        /// </summary>
        /// <param name="services">Коллекция с зависимостями</param>
        /// <returns>Сконфигурированный экземпляр, упакованный в <see cref="IServiceCollection"/></returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
            => services
            .AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<DbAppContext>()))
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IUserRepository, UserRepository>()
            .AddTransient<IUserService, UserService>()
            .AddScoped<ISellerReviewRepository, SellerReviewRepository>()
            .AddTransient<ISellerReviewService,SellerReviewService>()
            .AddTransient<IInstrumentTypeRepository,InstrumentTypeRepository>()
            .AddTransient<IInstrumentTypeService,InstrumentTypeService>()
            .AddTransient<IOfferRepository, OfferRepository>()
            .AddTransient<IOfferService, OfferService>()
            .AddTransient<ISiteFileRepository, SiteFileRepository>()
            .AddTransient<ISiteFileService, SiteFileService>()
            .AddLogging();
    }
}
