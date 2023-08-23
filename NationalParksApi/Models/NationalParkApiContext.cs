using Microsoft.EntityFrameworkCore;

namespace NationalParksApi.Models
{
    public class NationalParkApiContext : DbContext
    {
        public DbSet<NationalPark> NationalParks { get; set; }
        public NationalParkApiContext(DbContextOptions options) : base(options) { }
    }
}