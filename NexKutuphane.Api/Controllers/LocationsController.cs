using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Locations;

namespace NexKutuphane.Api.Controllers;

[Route("api/locations")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("sections")]
    public async Task<IActionResult> GetSections()
    {
        var result = await _locationService.GetSectionsAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("cabinets")]
    public async Task<IActionResult> GetCabinets([FromQuery] int? sectionId)
    {
        var result = await _locationService.GetCabinetsAsync(sectionId);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("shelves")]
    public async Task<IActionResult> GetShelves([FromQuery] int? cabinetId)
    {
        var result = await _locationService.GetShelvesAsync(cabinetId);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("book-locations")]
    public async Task<IActionResult> GetBookLocations()
    {
        var result = await _locationService.GetBookLocationsAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("book-locations/book/{bookId:int}")]
    public async Task<IActionResult> GetBookLocationsByBookId(int bookId)
    {
        var result = await _locationService.GetBookLocationsByBookIdAsync(bookId);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost("book-locations")]
    public async Task<IActionResult> CreateBookLocation([FromBody] BookLocationCreateRequest request)
    {
        var result = await _locationService.CreateBookLocationAsync(request);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut("book-locations/{id:int}")]
    public async Task<IActionResult> UpdateBookLocation(int id, [FromBody] BookLocationUpdateRequest request)
    {
        var result = await _locationService.UpdateBookLocationAsync(id, request);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpDelete("book-locations/{id:int}")]
    public async Task<IActionResult> DeleteBookLocation(int id)
    {
        var result = await _locationService.DeleteBookLocationAsync(id);

        if (!result.BasariliMi)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}