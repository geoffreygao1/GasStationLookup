using Microsoft.EntityFrameworkCore;

namespace GasStationLookupApi.Models
{
  public class GasStationLookupApiContext : DbContext
  {
    public DbSet<Company> Companies { get; set; }

    public GasStationLookupApiContext(DbContextOptions<GasStationLookupApiContext> options) : base(options)
    {
    }
  }
}