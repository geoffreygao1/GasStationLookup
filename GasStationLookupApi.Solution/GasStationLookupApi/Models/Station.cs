using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GasStationLookupApi.Models
{
  public class Station
  {
    [JsonIgnore]
    public int StationId { get; set; }
    [Required]
    [StringLength(200)]
    public string Address { get; set; }
    [Required]
    [StringLength(30)]
    public string City { get; set; }
    [Required]
    [StringLength(2)]
    public string State { get; set; }
    [Required]
    public int CompanyId { get; set; }
    [JsonIgnore]
    public Company Company { get; set; }

  }
}