namespace NexKutuphane.Domain.Entities;

public class RolYetki
{
    public int RolId { get; set; }

    public Rol Rol { get; set; } = null!;

    public int YetkiId { get; set; }

    public Yetki Yetki { get; set; } = null!;
}