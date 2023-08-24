

using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess.Db;

namespace MusicShop.Migrator
{
    /// <summary>
    /// Контекст о базе даннных, для миграций.
    /// </summary>
    public class MigrationDbContext : DbAppContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options) { }
    }
}
