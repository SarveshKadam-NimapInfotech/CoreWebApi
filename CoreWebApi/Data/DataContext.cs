

using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<WebApi> WebApis { get; set; }
    }
}
