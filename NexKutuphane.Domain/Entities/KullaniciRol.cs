namespace NexKutuphane.Domain.Entities;

public class KullaniciRol
{
    public int KullaniciId { get; set; }

    public Kullanici Kullanici { get; set; } = null!;

    public int RolId { get; set; }

    public Rol Rol { get; set; } = null!;
}