namespace superhero.Models
{
  public class Weapon
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int SuperHeroId { get; set; }
    public SuperHero? SuperHero { get; set; }
  }
}