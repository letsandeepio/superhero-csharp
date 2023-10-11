using System.Text.Json.Serialization;

namespace superhero.Models
{
  public class Backpack
  {
    public int Id { get; set; }
    public string? Description { get; set; }
    public int SuperHeroId { get; set; }
    [JsonIgnore]
    public SuperHero? SuperHero { get; set; }
  }
}