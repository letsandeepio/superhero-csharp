using Microsoft.AspNetCore.Mvc;

namespace superhero.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuperPowerController : ControllerBase
  {

    private readonly DataContext _context;

    public SuperPowerController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperPower>>> Get()
    {
      return Ok(await _context.SuperPowers.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperPower>> Get(int id)
    {
      var power = await _context.SuperPowers.FindAsync(id);
      if (power == null)
      {
        return NotFound();
      }
      return Ok(power);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperPower>>> Post(SuperPower power)
    {

      power.Id = 0;

      _context.SuperPowers.Add(power);
      await _context.SaveChangesAsync();

      return Ok(await _context.SuperPowers.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<SuperPower>>> Put(SuperPower power)
    {
      var powerToUpdate = await _context.SuperPowers.FindAsync(power.Id);
      if (powerToUpdate == null)
      {
        return BadRequest("Power not found");
      }

      _context.Entry(powerToUpdate).CurrentValues.SetValues(power);
      await _context.SaveChangesAsync();
      return Ok(await _context.SuperPowers.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperPower>>> Delete(int id)
    {
      var powerToDelete = await _context.SuperPowers.FindAsync(id);
      if (powerToDelete == null)
      {
        return BadRequest("Power not found");
      }

      _context.SuperPowers.Remove(powerToDelete);
      await _context.SaveChangesAsync();
      return Ok(await _context.SuperPowers.ToListAsync());
    }
  }
}