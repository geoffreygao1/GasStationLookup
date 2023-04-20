using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GasStationLookupApi.Models
{
  public class Company
  {
    public int CompanyId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [JsonIgnore]
    public List<Station> Stations { get; set; }
  }
}