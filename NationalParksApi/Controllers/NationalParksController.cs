using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParksApi.Models;

namespace NationalParksApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NationalParksController : ControllerBase
{
    private readonly ILogger<NationalParksController> _logger;
    private readonly NationalParksApiContext _db;

    public NationalParksController(ILogger<NationalParksController> logger, NationalParksApiContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NationalPark>>> GetPage(int page)
    {
        int parksPerPage = 5;
        return await _db.NationalParks
            .Skip(page * parksPerPage)
            .Take(parksPerPage)
            .ToListAsync();
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<NationalPark>> GetPark(int id)
    {
        NationalPark nationalPark = await _db.NationalParks.FirstOrDefaultAsync(m => m.NationalParkId == id);
        if (nationalPark == null)
        {
            return NotFound();
        }
        return nationalPark;
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<NationalPark>> GetPark(string name)
    {
        NationalPark nationalPark = await _db.NationalParks.FirstOrDefaultAsync(m => m.Name == name);
        if (nationalPark == null)
        {
            return NotFound();
        }
        return nationalPark;
    }

    [HttpPost]
    public async Task<ActionResult<NationalPark>> PostPark(NationalPark nationalPark)
    {
        if (nationalPark.NationalParkId != 0)
        {
            return BadRequest();
        }
        _db.NationalParks.Add(nationalPark);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPark), new { id = nationalPark.NationalParkId }, nationalPark);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<NationalPark>> PutPark(int id, NationalPark nationalPark)
    {
        if (id != nationalPark.NationalParkId)
        {
            return BadRequest();
        }
        else if (!_db.NationalParks.Any(m => m.NationalParkId == id))
        {
            return NotFound();
        }
        _db.NationalParks.Update(nationalPark);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
        NationalPark nationalPark = await _db.NationalParks.FindAsync(id);
        if (nationalPark == null)
        {
            return NotFound();
        }
        _db.NationalParks.Remove(nationalPark);
        await _db.SaveChangesAsync();

        return NoContent();
    }

}
