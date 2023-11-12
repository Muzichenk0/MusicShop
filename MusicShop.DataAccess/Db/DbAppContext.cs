using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MusicShop.DataAccess.Db
{
    /// <summary>
    /// Контекст базы данных. Производная сущность в отношении наследования от базовой <see cref="DbContext"/>
    /// </summary>
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
            t => t
            .GetInterfaces()
            .Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
    }
}
