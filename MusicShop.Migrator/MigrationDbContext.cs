

using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess.Db;

namespace MusicShop.Migrator
{
    public class MigrationDbContext : DbAppContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options) { }
    }
}
