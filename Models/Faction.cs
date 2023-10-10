namespace superhero.Models
{
  public class Faction
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<SuperHero>? SuperHeroes { get; set; }
  }
}