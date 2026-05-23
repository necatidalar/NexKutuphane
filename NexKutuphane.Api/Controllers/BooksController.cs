using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Books;

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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _bookService.GetByIdAsync(id);

        if (!result.BasariliMi)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookCreateRequest request)
    {
        var result = await _bookService.CreateAsync(request);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] BookUpdateRequest request)
    {
        var result = await _bookService.UpdateAsync(id, request);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _bookService.DeleteAsync(id);

        if (!result.BasariliMi)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}