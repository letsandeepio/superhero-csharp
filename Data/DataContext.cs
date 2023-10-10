

namespace superhero.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }

    public DbSet<SuperPower> SuperPowers { get; set; }

    public DbSet<SuperHeroSuperPower> SuperHeroSuperPowers { get; set; }
  }
}