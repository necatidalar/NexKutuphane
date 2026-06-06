using Microsoft.EntityFrameworkCore;
using NexKutuphane.Domain.Entities;

namespace NexKutuphane.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
    public DbSet<Rol> Roller => Set<Rol>();
    public DbSet<KullaniciRol> KullaniciRolleri => Set<KullaniciRol>();
    public DbSet<Yetki> Yetkiler => Set<Yetki>();
    public DbSet<RolYetki> RolYetkileri => Set<RolYetki>();

    public DbSet<Kitap> Kitaplar => Set<Kitap>();
    public DbSet<Yazar> Yazarlar => Set<Yazar>();
    public DbSet<KitapYazar> KitapYazarlari => Set<KitapYazar>();
    public DbSet<Yayinevi> Yayinevleri => Set<Yayinevi>();
    public DbSet<Kategori> Kategoriler => Set<Kategori>();
    public DbSet<Dil> Diller => Set<Dil>();

    public DbSet<Uye> Uyeler => Set<Uye>();
    public DbSet<UyeTuru> UyeTurleri => Set<UyeTuru>();
    public DbSet<Sinif> Siniflar => Set<Sinif>();
    public DbSet<Sube> Subeler => Set<Sube>();
    public DbSet<Bolum> Bolumler => Set<Bolum>();
    public DbSet<Alan> Alanlar => Set<Alan>();

    public DbSet<YerlesimBolumu> YerlesimBolumleri => Set<YerlesimBolumu>();
    public DbSet<Dolap> Dolaplar => Set<Dolap>();
    public DbSet<Raf> Raflar => Set<Raf>();
    public DbSet<KitapKonum> KitapKonumlari => Set<KitapKonum>();
    public DbSet<KitapKopya> KitapKopyalari => Set<KitapKopya>();
    public DbSet<OduncIslem> OduncIslemleri => Set<OduncIslem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<KullaniciRol>()
            .HasKey(x => new { x.KullaniciId, x.RolId });

        modelBuilder.Entity<RolYetki>()
            .HasKey(x => new { x.RolId, x.YetkiId });

        modelBuilder.Entity<KitapYazar>()
            .HasKey(x => new { x.KitapId, x.YazarId });

        modelBuilder.Entity<Kitap>()
            .HasOne(x => x.OrijinalDil)
            .WithMany(x => x.OrijinalDilKitaplari)
            .HasForeignKey(x => x.OrijinalDilId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Kitap>()
            .HasOne(x => x.CeviriDil)
            .WithMany(x => x.CeviriDilKitaplari)
            .HasForeignKey(x => x.CeviriDilId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Kategori>()
            .HasOne(x => x.UstKategori)
            .WithMany(x => x.AltKategoriler)
            .HasForeignKey(x => x.UstKategoriId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Uye>()
            .HasOne(x => x.UyeTuru)
            .WithMany(x => x.Uyeler)
            .HasForeignKey(x => x.UyeTuruId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Uye>()
            .HasOne(x => x.Sinif)
            .WithMany(x => x.Uyeler)
            .HasForeignKey(x => x.SinifId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Uye>()
            .HasOne(x => x.Sube)
            .WithMany(x => x.Uyeler)
            .HasForeignKey(x => x.SubeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Uye>()
            .HasOne(x => x.Bolum)
            .WithMany(x => x.Uyeler)
            .HasForeignKey(x => x.BolumId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Uye>()
            .HasOne(x => x.Alan)
            .WithMany(x => x.Uyeler)
            .HasForeignKey(x => x.AlanId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Alan>()
            .HasOne(x => x.Bolum)
            .WithMany(x => x.Alanlar)
            .HasForeignKey(x => x.BolumId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Uye>()
            .HasIndex(x => x.OkulNo)
            .IsUnique()
            .HasFilter("[OkulNo] IS NOT NULL");

        modelBuilder.Entity<UyeTuru>()
            .HasIndex(x => x.UyeTuruKodu)
            .IsUnique();

        modelBuilder.Entity<Sinif>()
            .HasIndex(x => x.SinifAdi)
            .IsUnique();

        modelBuilder.Entity<Sube>()
            .HasIndex(x => x.SubeAdi)
            .IsUnique();

        modelBuilder.Entity<Dolap>()
            .HasOne(x => x.YerlesimBolumu)
            .WithMany(x => x.Dolaplar)
            .HasForeignKey(x => x.YerlesimBolumuId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Raf>()
            .HasOne(x => x.Dolap)
            .WithMany(x => x.Raflar)
            .HasForeignKey(x => x.DolapId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<KitapKonum>()
            .HasOne(x => x.Kitap)
            .WithMany(x => x.KitapKonumlari)
            .HasForeignKey(x => x.KitapId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<KitapKonum>()
            .HasOne(x => x.Raf)
            .WithMany(x => x.KitapKonumlari)
            .HasForeignKey(x => x.RafId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<YerlesimBolumu>()
            .HasIndex(x => x.BolumKodu)
            .IsUnique()
            .HasFilter("[BolumKodu] IS NOT NULL");

        modelBuilder.Entity<Dolap>()
            .HasIndex(x => x.DolapKodu)
            .IsUnique()
            .HasFilter("[DolapKodu] IS NOT NULL");

        modelBuilder.Entity<Raf>()
            .HasIndex(x => x.RafKodu)
            .IsUnique()
            .HasFilter("[RafKodu] IS NOT NULL");

        modelBuilder.Entity<KitapKonum>()
            .HasIndex(x => new { x.KitapId, x.RafId })
            .IsUnique();

        modelBuilder.Entity<KitapKopya>()
            .HasOne(x => x.Kitap)
            .WithMany(x => x.KitapKopyalari)
            .HasForeignKey(x => x.KitapId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<KitapKopya>()
            .HasOne(x => x.Raf)
            .WithMany(x => x.KitapKopyalari)
            .HasForeignKey(x => x.RafId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<KitapKopya>()
            .HasIndex(x => x.Barkod)
            .IsUnique();

        modelBuilder.Entity<KitapKopya>()
            .HasIndex(x => x.DemirbasNo)
            .IsUnique()
            .HasFilter("[DemirbasNo] IS NOT NULL");

        modelBuilder.Entity<OduncIslem>()
    .HasOne(x => x.Uye)
    .WithMany(x => x.OduncIslemleri)
    .HasForeignKey(x => x.UyeId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OduncIslem>()
            .HasOne(x => x.KitapKopya)
            .WithMany(x => x.OduncIslemleri)
            .HasForeignKey(x => x.KitapKopyaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OduncIslem>()
            .HasOne(x => x.OduncVerenKullanici)
            .WithMany()
            .HasForeignKey(x => x.OduncVerenKullaniciId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OduncIslem>()
            .HasOne(x => x.IadeAlanKullanici)
            .WithMany()
            .HasForeignKey(x => x.IadeAlanKullaniciId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OduncIslem>()
            .HasIndex(x => x.KitapKopyaId);

        modelBuilder.Entity<OduncIslem>()
            .HasIndex(x => x.UyeId);

        modelBuilder.Entity<OduncIslem>()
            .HasIndex(x => x.Durum);

        modelBuilder.Entity<OduncIslem>()
            .Property(x => x.CezaTutari)
            .HasPrecision(18, 2);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}