using Components.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Components.API.DBContexts
{
    public class BreweryDBContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }

        private string ConnectionString { get; set; }

        public BreweryDBContext(IConfiguration appConfig)
        {
            // Pull connection string from AppSettings Configuration
            ConnectionString = appConfig.GetValue<string>("DbConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
