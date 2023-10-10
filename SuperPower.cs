namespace superhero
{
  public class SuperPower
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public ICollection<SuperHeroSuperPower>? SuperHeroSuperPowers { get; set; }
  }
}