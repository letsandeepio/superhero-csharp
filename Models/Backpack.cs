namespace superhero.Models
{
  public class Backpack
  {
    public int Id { get; set; }
    public string? Description { get; set; }
    public int SuperHeroId { get; set; }
    public SuperHero? SuperHero { get; set; }
  }
}