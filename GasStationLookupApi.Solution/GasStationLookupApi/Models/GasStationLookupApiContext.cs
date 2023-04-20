using Microsoft.EntityFrameworkCore;

namespace GasStationLookupApi.Models
{
  public class GasStationApiContext : DbContext
  {
    public DbSet<Company> Companies { get; set; }

    public GasStationApiContext(DbContextOptions<GasStationApiContext> options) : base(options)
    {
    }
  }
}