using System.Text.Json.Serialization;

namespace superhero.Models
{
  public class Faction
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    [JsonIgnore]
    public List<SuperHero>? SuperHeroes { get; set; }
  }
}