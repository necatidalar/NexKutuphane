using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;

namespace NexKutuphane.Api.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _authorService.GetAllAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}