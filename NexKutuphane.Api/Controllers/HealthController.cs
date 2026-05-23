using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    private readonly AppDbContext _context;

    public HealthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            basariliMi = true,
            mesaj = "NexKütüphane API çalışıyor.",
            tarih = DateTime.Now
        });
    }

    [HttpGet("database")]
    public async Task<IActionResult> CheckDatabase()
    {
        var canConnect = await _context.Database.CanConnectAsync();

        return Ok(new
        {
            basariliMi = canConnect,
            mesaj = canConnect
                ? "SQL Server bağlantısı başarılı."
                : "SQL Server bağlantısı başarısız.",
            tarih = DateTime.Now
        });
    }
}