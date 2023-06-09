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
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class CompaniesController : ControllerBase
  {
    private readonly GasStationLookupApiContext _context;

    public CompaniesController(GasStationLookupApiContext context)
    {
      _context = context;
    }

    // GET: api/Companies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies(string name, string sortOrder)
    {
      IQueryable<Company> query = _context.Companies.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (sortOrder != null)
      {
        switch (sortOrder.ToLower())
        {
          case "name_desc":
            query = query.OrderByDescending(s => s.Name);
            break;
          case "name":
            query = query.OrderBy(s => s.Name);
            break;
          default:
            query = query.OrderBy(s => s.CompanyId);
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

    // GET: api/Companies/Random
    [HttpGet("Random")]
    public async Task<ActionResult<Company>> GetRandom()
    {
      Random rand = new Random();
      int toSkip = rand.Next(0, _context.Companies.Count());
      return await _context.Companies.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).FirstAsync();
    }

    // GET: api/Companies/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Company>> GetCompany(int id)
    {
      var company = await _context.Companies.FindAsync(id);

      if (company == null)
      {
        return NotFound();
      }

      return company;
    }

    // GET: api/Companies/5/Stations
    [HttpGet("{id}/Stations")]
    public async Task<ActionResult<List<Station>>> GetStationsForCompany(int id)
    {
      IQueryable<Station> query = _context.Stations
                                .Where(station => station.CompanyId == id)
                                .AsQueryable();

      if (query == null)
      {
        return NotFound();
      }

      if (query.Count() == 0)
      {
        return NotFound();
      }

      return await query.ToListAsync();
    }

    // PUT: api/Companies/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCompany(int id, Company company)
    {
      if (id != company.CompanyId)
      {
        return BadRequest();
      }

      _context.Entry(company).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CompanyExists(id))
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

    // POST: api/Companies
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Company>> PostCompany(Company company)
    {
      _context.Companies.Add(company);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
    }

    // DELETE: api/Companies/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
      var company = await _context.Companies.FindAsync(id);
      if (company == null)
      {
        return NotFound();
      }

      _context.Companies.Remove(company);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CompanyExists(int id)
    {
      return _context.Companies.Any(e => e.CompanyId == id);
    }
  }
}
