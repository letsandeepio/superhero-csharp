using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace superhero.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuperHeroController : ControllerBase
  {

    private static List<SuperHero> heroes = new List<SuperHero>
      {
        new SuperHero { Id = 1, Name = "Spiderman 2", FirstName = "Peter", LastName = "Parker", PlaceOfBirth = "New York" },
        new SuperHero { Id = 2, Name = "Batman 2", FirstName = "Bruce", LastName = "Wayne", PlaceOfBirth = "Gotham" },
      };

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
      return Ok(heroes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
      var hero = heroes.FirstOrDefault(x => x.Id == id);
      if (hero == null)
      {
        return NotFound();
      }
      return Ok(hero);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> Post(SuperHero hero)
    {
      heroes.Add(hero);
      return Ok(heroes);
    }

    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> Put(SuperHero hero)
    {
      var heroToUpdate = heroes.FirstOrDefault(x => x.Id == hero.Id);
      if (heroToUpdate == null)
      {
        return NotFound();
      }
      heroes.Remove(heroToUpdate);
      heroes.Add(hero);
      return Ok(heroes);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> Delete(int id)
    {
      var heroToDelete = heroes.FirstOrDefault(x => x.Id == id);
      if (heroToDelete == null)
      {
        return NotFound();
      }
      heroes.Remove(heroToDelete);
      return Ok(heroes);
    }

  }
}
