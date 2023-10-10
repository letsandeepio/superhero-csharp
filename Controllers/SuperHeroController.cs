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

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> Post(SuperHero hero)
    {
      heroes.Add(hero);
      return Ok(heroes);
    }
  }
}
