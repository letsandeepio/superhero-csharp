using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using superhero.DTOs;
using superhero.Models;

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
      // return super herows with backpacks
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
    public async Task<ActionResult<List<SuperHero>>> Post(SuperHeroCreateDto request)
    {

      var newSuperHero = new SuperHero
      {
        Name = request.name,
      };

      var backpack = new Backpack
      {
        Description = request.backpack.Description,
        SuperHero = newSuperHero
      };

      newSuperHero.Backpack = backpack;

      _context.SuperHeroes.Add(newSuperHero);

      await _context.SaveChangesAsync();
      return Ok(await _context.SuperHeroes.Include(s => s.Backpack).ToListAsync());
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
