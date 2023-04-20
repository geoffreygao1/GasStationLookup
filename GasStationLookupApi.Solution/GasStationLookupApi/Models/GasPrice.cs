using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GasStationLookupApi.Models
{
  public class GasPrice
  {
    [JsonIgnore]
    public int GasPriceId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public float Diesel { get; set; }
    public float Unleaded { get; set; }
    public float Premium { get; set; }
    public int StationId { get; set; }
    [JsonIgnore]
    public Station Station { get; set; }


  }
}