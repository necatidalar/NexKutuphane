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

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}