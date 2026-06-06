using Microsoft.AspNetCore.Mvc;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Members;

namespace NexKutuphane.Api.Controllers;

[Route("api/members")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _memberService.GetAllAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _memberService.GetByIdAsync(id);

        if (!result.BasariliMi)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("lookups")]
    public async Task<IActionResult> GetLookups()
    {
        var result = await _memberService.GetLookupsAsync();

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MemberCreateRequest request)
    {
        var result = await _memberService.CreateAsync(request);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] MemberUpdateRequest request)
    {
        var result = await _memberService.UpdateAsync(id, request);

        if (!result.BasariliMi)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _memberService.DeleteAsync(id);

        if (!result.BasariliMi)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}