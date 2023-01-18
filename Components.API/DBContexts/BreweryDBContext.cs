using Components.API.Models;
using Components.API.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Components.API.DBContexts
{
    public class BreweryDBContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }

        private string ConnectionString { get; set; }

        IConfiguration _configuration { get; set; }

        public BreweryDBContext(DbContextOptions<BreweryDBContext> options, IConfiguration configuration): base(options) 
        { 
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(BreweryAPIConstants.CONSTANT_BREWERY_API_DB_CONNECTION_STRING));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().ToTable("Beers");
        }

    }
}
