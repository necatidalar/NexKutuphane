using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;

namespace NexKutuphane.Api.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _bookService.GetAllAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}