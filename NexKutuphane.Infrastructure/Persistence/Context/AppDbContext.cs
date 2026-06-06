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

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}