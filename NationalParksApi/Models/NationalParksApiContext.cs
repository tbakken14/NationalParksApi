using Microsoft.EntityFrameworkCore;

namespace NationalParksApi.Models
{
    public class NationalParksApiContext : DbContext
    {
        public DbSet<NationalPark> NationalParks { get; set; }
        public NationalParksApiContext(DbContextOptions options) : base(options) { }
    }
}