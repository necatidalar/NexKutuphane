namespace NexKutuphane.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

    public DateTime? GuncellemeTarihi { get; set; }

    public bool AktifMi { get; set; } = true;
}