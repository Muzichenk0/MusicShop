using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess.Db;
using MusicShop.Infrastructure.MapProfile.User;
using MusicShop.Registrator;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using MusicShop.Contracts.User;
using MusicShop.Infrastructure.MapProfile.SellerReview;
using MusicShop.Infrastructure.MapProfile.InstrumentType;
using MusicShop.Infrastructure.MapProfile.Offer;

namespace MusicShop.WebApi
{
    /// <summary>
    ///  онкретна€ ссылочна€ модель, определ€юща€ интерфейс модели программы.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// “очка дл€ входа в программное решение, асинхронно запускающа€с€.
        /// </summary>
        /// <param name="args">»нструкции из CLI</param>
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IDbContextOptionsConfigurator<DbAppContext>, DbContextConfiguration>();
            builder.Services
                .AddDbContext<DbAppContext>((sProvider, dbContextOptBuilder)
                    => sProvider
                .GetRequiredService<IDbContextOptionsConfigurator<DbAppContext>>()
                .Configure((DbContextOptionsBuilder<DbAppContext>)dbContextOptBuilder));


            builder.Services
               .AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            builder.Services.ConfigureServices();

            builder.Services.AddControllers();

            #region Authentication and Authorization

            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddAuthentication();

            builder.Services.AddAuthorization();

            #endregion

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Apterra Adverts Api", Version = "V1" });

                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "documentation.xml")));
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
                       $"{typeof(CreateUserRequest).Assembly.GetName().Name}.xml")));
            });

            using WebApplication app = builder.Build();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHsts();

            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Token-Expired")
                .AllowCredentials()
                .WithOrigins("http://localhost:791"));

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            await app
                .RunAsync();
        }
        /// <summary>
        /// Ёлемент поведени€ статического интерфейса дл€ получени€ настроек механизма соотношени€(маппинга).
        /// </summary>
        /// <returns>Ёкземпл€р <see cref="MapperConfiguration"/></returns>
        public static MapperConfiguration GetMapperConfiguration()
            => new MapperConfiguration(cfgExpression =>
            {
                cfgExpression.AddProfile<UserProfile>();
                cfgExpression.AddProfile<SellerReviewProfile>();
                cfgExpression.AddProfile<InstrumentTypeProfile>();
                cfgExpression.AddProfile<OfferProfile>();
            });
    }
}