using Microsoft.EntityFrameworkCore;

namespace GasStationLookupApi.Models
{
  public class GasStationLookupApiContext : DbContext
  {
    public DbSet<Company> Companies { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<GasPrice> GasPrices { get; set; }

    public GasStationLookupApiContext(DbContextOptions<GasStationLookupApiContext> options) : base(options)
    {
    }
  }
}