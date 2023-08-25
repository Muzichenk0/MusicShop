#region auto-created expressions/instructions
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run(); 
#endregion
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess.Db;
using MusicShop.Infrastructure.MapProfile.User;
using MusicShop.Registrator;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using MusicShop.Contracts.User;

namespace MusicShop.WebApi
{
    public static class Program
    {
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

                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(CreateUserRequest).Assembly.GetName().Name}.xml")));
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(UserInfoResponse).Assembly.GetName().Name}.xml")));
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(UpdateUserRequest).Assembly.GetName().Name}.xml")));
                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
                $"{typeof(DeleteUserRequest).Assembly.GetName().Name}.xml")));

                options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "documentation.xml")));
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
        public static MapperConfiguration GetMapperConfiguration()
            => new MapperConfiguration(cfgExpression => cfgExpression
            .AddProfile<UserProfile>());
    }
}