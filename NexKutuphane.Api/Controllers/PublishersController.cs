using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;

namespace NexKutuphane.Api.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _publisherService.GetAllAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}