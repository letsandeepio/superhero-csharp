namespace superhero.Models;

public class SuperHero
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? PlaceOfBirth { get; set; }
  public Backpack? Backpack { get; set; }
  public List<Weapon>? Weapons { get; set; }
  public List<Faction>? Factions { get; set; }
}
