using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using superhero.Data;

namespace superhero.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuperHeroController : ControllerBase
  {

    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
      return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
      var hero = await _context.SuperHeroes.FindAsync(id);
      if (hero == null)
      {
        return NotFound();
      }
      return Ok(hero);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> Post(SuperHero hero)
    {

      hero.Id = 0;

      _context.SuperHeroes.Add(hero);
      await _context.SaveChangesAsync();

      return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> Put(SuperHero hero)
    {
      var heroToUpdate = await _context.SuperHeroes.FindAsync(hero.Id);
      if (heroToUpdate == null)
      {
        return BadRequest("Hero not found");
      }

      _context.Entry(heroToUpdate).CurrentValues.SetValues(hero);
      await _context.SaveChangesAsync();
      return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> Delete(int id)
    {
      var heroToDelete = await _context.SuperHeroes.FindAsync(id);

      if (heroToDelete == null)
      {
        return BadRequest("Hero not found");
      }

      _context.SuperHeroes.Remove(heroToDelete);
      await _context.SaveChangesAsync();

      return Ok(await _context.SuperHeroes.ToListAsync());
    }

  }
}
