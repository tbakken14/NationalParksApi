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
}
