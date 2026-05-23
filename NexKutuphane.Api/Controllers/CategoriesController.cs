using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;

namespace NexKutuphane.Api.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}