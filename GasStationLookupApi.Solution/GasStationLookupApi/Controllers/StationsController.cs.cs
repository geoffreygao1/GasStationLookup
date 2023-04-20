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
  public class StationsController : ControllerBase
  {
    private readonly GasStationLookupApiContext _context;

    public StationsController(GasStationLookupApiContext context)
    {
      _context = context;
    }

    // GET: api/Stations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Station>>> GetStations(string address, string city, string state, string sortOrder)
    {
      IQueryable<Station> query = _context.Stations.AsQueryable();
      if (address != null)
      {
        query = query.Where(entry => entry.Address == address);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }
      if (sortOrder != null)
      {

        switch (sortOrder.ToLower())
        {
          case "city_desc":
            query = query.OrderByDescending(s => s.City);
            break;
          case "city":
            query = query.OrderBy(s => s.City);
            break;
          case "state_desc":
            query = query.OrderByDescending(s => s.State);
            break;
          case "state":
            query = query.OrderBy(s => s.State);
            break;
          default:
            query = query.OrderBy(s => s.StationId);
            break;
        }
      }

      if (query.Count() != 0)
      {
        return await query.ToListAsync();
      }
      else
      {
        return NotFound();
      }
    }

    // GET: api/Stations/Random
    [HttpGet("Random")]
    public async Task<ActionResult<Station>> GetRandom()
    {
      Random rand = new Random();
      int toSkip = rand.Next(0, _context.Stations.Count());
      return await _context.Stations.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).FirstAsync();
    }

    // GET: api/Stations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Station>> GetStation(int id)
    {
      var station = await _context.Stations.FindAsync(id);

      if (station == null)
      {
        return NotFound();
      }

      return station;
    }

    // GET: api/Stations/5/GasPrices
    [HttpGet("{id}/GasPrices")]
    public async Task<ActionResult<List<GasPrice>>> GetGasPricesForStation(int id)
    {
      IQueryable<GasPrice> query = _context.GasPrices
                                .Where(gasPrice => gasPrice.StationId == id)
                                .AsQueryable();

      if (query == null)
      {
        return NotFound();
      }

      return await query.ToListAsync();
    }

    // GET: api/Stations/5/AveragePrice/Unleaded
    [HttpGet("{id}/AveragePrice/{gasType}")]
    public async Task<ActionResult<String>> GetAverageGasPrice(int id, string gasType)
    {
      var station = await _context.Stations.FindAsync(id);

      if (station == null)
      {
        return NotFound();
      }

      IQueryable<GasPrice> query = _context.GasPrices
                          .Where(gasPrice => gasPrice.StationId == id)
                          .AsQueryable();

      float result = 0;
      if (gasType == "Diesel")
      {
        foreach (GasPrice gasPrice in query)
        {
          result += gasPrice.Diesel;
        }
        float average = result / station.GasPrices.Count();
        return average.ToString("#.##");
      }
      else if (gasType == "Unleaded")
      {
        foreach (GasPrice gasPrice in query)
        {
          result += gasPrice.Unleaded;
        }
        float average = result / station.GasPrices.Count();
        return average.ToString("#.##");
      }
      else if (gasType == "Premium")
      {
        foreach (GasPrice gasPrice in query)
        {
          result += gasPrice.Premium;
        }
        float average = result / station.GasPrices.Count();
        return average.ToString("#.##");
      }
      else
      {
        return NotFound();
      }

    }

    // PUT: api/Stations/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStation(int id, Station station)
    {
      if (id != station.StationId)
      {
        return BadRequest();
      }

      _context.Entry(station).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StationExists(id))
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

    // POST: api/Stations
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Station>> PostStation(Station station)
    {
      _context.Stations.Add(station);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetStation", new { id = station.StationId }, station);
    }

    // DELETE: api/Stations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStation(int id)
    {
      var station = await _context.Stations.FindAsync(id);
      if (station == null)
      {
        return NotFound();
      }

      _context.Stations.Remove(station);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool StationExists(int id)
    {
      return _context.Stations.Any(e => e.StationId == id);
    }
  }
}
