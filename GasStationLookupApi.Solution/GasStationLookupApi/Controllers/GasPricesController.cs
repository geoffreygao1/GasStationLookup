using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GasStationLookupApi.Models;

namespace GasStationLookupApi.Controllers
{
  // [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class GasPricesController : ControllerBase
  {
    private readonly GasStationLookupApiContext _context;

    public GasPricesController(GasStationLookupApiContext context)
    {
      _context = context;
    }

    // GET: api/GasPrices
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GasPrice>>> GetGasPricess(string sortOrder)
    {
      IQueryable<GasPrice> query = _context.GasPrices.AsQueryable();

      if (sortOrder != null)
      {
        switch (sortOrder.ToLower())
        {
          case "unleaded_desc":
            query = query.OrderByDescending(s => s.Unleaded);
            break;
          case "unleaded":
            query = query.OrderBy(s => s.Unleaded);
            break;
          case "premium_desc":
            query = query.OrderByDescending(s => s.Premium);
            break;
          case "premium":
            query = query.OrderBy(s => s.Premium);
            break;
          case "diesel_desc":
            query = query.OrderByDescending(s => s.Diesel);
            break;
          case "diesel":
            query = query.OrderBy(s => s.Diesel);
            break;
          case "date_desc":
            query = query.OrderByDescending(s => s.Date);
            break;
          case "date":
            query = query.OrderBy(s => s.Date);
            break;
          default:
            query = query.OrderBy(s => s.GasPriceId);
            break;
        }
      }
      return await query.ToListAsync();
    }

    // GET: api/GasPrices/Random
    [HttpGet("Random")]
    public async Task<ActionResult<GasPrice>> GetRandom()
    {
      Random rand = new Random();
      int toSkip = rand.Next(0, _context.GasPrices.Count());
      return await _context.GasPrices.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).FirstAsync();
    }
    // GET: api/GasPrices/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GasPrice>> GetGasPrice(int id)
    {
      var gasPrice = await _context.GasPrices.FindAsync(id);

      if (gasPrice == null)
      {
        return NotFound();
      }

      return gasPrice;
    }

    // PUT: api/GasPrices/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGasPrice(int id, GasPrice gasPrice)
    {
      if (id != gasPrice.GasPriceId)
      {
        return BadRequest();
      }

      _context.Entry(gasPrice).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GasPriceExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/GasPrices
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<GasPrice>> PostGasPrice(GasPrice gasPrice)
    {
      _context.GasPrices.Add(gasPrice);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetGasPrice", new { id = gasPrice.GasPriceId }, gasPrice);
    }

    // DELETE: api/GasPrices/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGasPrice(int id)
    {
      var gasPrice = await _context.GasPrices.FindAsync(id);
      if (gasPrice == null)
      {
        return NotFound();
      }

      _context.GasPrices.Remove(gasPrice);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool GasPriceExists(int id)
    {
      return _context.GasPrices.Any(e => e.GasPriceId == id);
    }
  }
}
