using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Rol : BaseEntity
{
    public string RolAdi { get; set; } = string.Empty;

    public string RolKodu { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public ICollection<KullaniciRol> KullaniciRolleri { get; set; } = new List<KullaniciRol>();

    public ICollection<RolYetki> RolYetkileri { get; set; } = new List<RolYetki>();
}