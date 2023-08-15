using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Db
{
    internal interface IDbContextOptionsConfigurator<TContext> where TContext: DbContext
    {
        public void Configure(DbContextOptionsBuilder<TContext> opt);

    }
}
