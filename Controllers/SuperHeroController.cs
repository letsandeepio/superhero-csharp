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
      return Ok(await _context.SuperHeroes.Include(c => c.Weapons).Include(c => c.Backpack).Include(c => c.Factions).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
    {
      var hero = await _context.SuperHeroes.Include(c => c.Weapons).Include(c => c.Backpack).Include(c => c.Factions).FirstOrDefaultAsync(c => c.Id == id);

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

      var weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, SuperHero = newSuperHero }).ToList();

      var factions = request.Factions.Select(f => new Faction { Name = f.Name, SuperHeroes = new List<SuperHero> { newSuperHero } }).ToList();

      newSuperHero.Backpack = backpack;
      newSuperHero.Weapons = weapons;
      newSuperHero.Factions = factions;

      _context.SuperHeroes.Add(newSuperHero);

      await _context.SaveChangesAsync();
      return Ok(await _context.SuperHeroes.Include(s => s.Backpack).Include(c => c.Weapons).ToListAsync());
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
