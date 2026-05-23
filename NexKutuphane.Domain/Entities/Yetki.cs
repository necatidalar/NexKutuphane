using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Yetki : BaseEntity
{
    public string YetkiKodu { get; set; } = string.Empty;

    public string YetkiAdi { get; set; } = string.Empty;

    public string ModulAdi { get; set; } = string.Empty;

    public string IslemAdi { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public ICollection<RolYetki> RolYetkileri { get; set; } = new List<RolYetki>();
}