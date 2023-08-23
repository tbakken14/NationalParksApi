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
    public async Task<ActionResult<IEnumerable<NationalPark>>> Get()
    {
        return await _db.NationalParks.ToListAsync();
    }

    [HttpGet("/[controller]/{id}")]
    public async Task<ActionResult<NationalPark>> Get(int id)
    {
        NationalPark nationalPark = await _db.NationalParks.FirstOrDefaultAsync(m => m.NationalParkId == id);
        if (nationalPark == null)
        {
            return NotFound();
        }
        return nationalPark;
    }

    [HttpPost]
    public async Task<ActionResult<NationalPark>> Post(NationalPark nationalPark)
    {
        if (nationalPark.NationalParkId != 0)
        {
            return BadRequest();
        }
        _db.NationalParks.Add(nationalPark);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = nationalPark.NationalParkId }, nationalPark);
    }

    [HttpPut("/[controller]/{id}")]
    public async Task<ActionResult<NationalPark>> Put(int id, NationalPark nationalPark)
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
}
