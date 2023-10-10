namespace superhero
{
  public class SuperHeroSuperPower
  {

    public int Id { get; set; }
    public int SuperHeroId { get; set; }
    public SuperHero SuperHero { get; set; }
    public int SuperPowerId { get; set; }
    public SuperPower SuperPower { get; set; }
  }
}