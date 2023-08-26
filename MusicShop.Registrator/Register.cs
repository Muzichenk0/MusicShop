using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.AppData.Contexts.SellerReview.Repository;
using MusicShop.AppData.Contexts.SellerReview.Services;
using MusicShop.AppData.Contexts.User.Repository;
using MusicShop.AppData.Contexts.User.Services;
using MusicShop.DataAccess.Contexts.SellerReview;
using MusicShop.DataAccess.Contexts.User;
using MusicShop.DataAccess.Db;
using MusicShop.Infrastructure.Repositories.Base;

namespace MusicShop.Registrator
{
    public static class Register
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
            => services
            .AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<DbAppContext>()))
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<ISellerReviewRepository, SellerReviewRepository>()
            .AddTransient<ISellerReviewService,SellerReviewService>()
            .AddLogging();
    }
}
