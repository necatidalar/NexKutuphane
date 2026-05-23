using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;

namespace NexKutuphane.Api.Controllers;

[Route("api/languages")]
[ApiController]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguagesController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _languageService.GetAllAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}