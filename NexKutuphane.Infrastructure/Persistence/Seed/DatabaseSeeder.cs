using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NexKutuphane.Domain.Entities;
using NexKutuphane.Domain.Enums;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Persistence.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await SeedRollerAsync(context);
        await SeedYetkilerAsync(context);
        await SeedAdminKullaniciAsync(context);
        await SeedAdminYetkileriAsync(context);

        await SeedDillerAsync(context);
        await SeedKategorilerAsync(context);
        await SeedYayinevleriAsync(context);
        await SeedYazarlarAsync(context);
        await SeedKitaplarAsync(context);
        await SeedUyeTanimVerileriAsync(context);
        await SeedUyelerAsync(context);
    }

    private static async Task SeedRollerAsync(AppDbContext context)
    {
        var roller = new List<Rol>
        {
            new()
            {
                RolAdi = "Yönetici",
                RolKodu = "ADMIN",
                Aciklama = "Sistemdeki tüm işlemleri yapabilir."
            },
            new()
            {
                RolAdi = "Kütüphane Görevlisi",
                RolKodu = "LIBRARY_STAFF",
                Aciklama = "Kitap, üye, ödünç ve iade işlemlerini yönetebilir."
            },
            new()
            {
                RolAdi = "Öğretmen",
                RolKodu = "TEACHER",
                Aciklama = "Raporları ve temel kütüphane kayıtlarını görüntüleyebilir."
            },
            new()
            {
                RolAdi = "Sınırlı Kullanıcı",
                RolKodu = "LIMITED_USER",
                Aciklama = "Sadece kendisine verilen sınırlı ekranlara erişebilir."
            }
        };

        foreach (var rol in roller)
        {
            var exists = await context.Roller.AnyAsync(x => x.RolKodu == rol.RolKodu);

            if (!exists)
            {
                await context.Roller.AddAsync(rol);
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedYetkilerAsync(AppDbContext context)
    {
        var yetkiler = new List<Yetki>
        {
            new() { YetkiKodu = "DASHBOARD_GORUNTULE", YetkiAdi = "Dashboard Görüntüleme", ModulAdi = "Dashboard", IslemAdi = "Görüntüle" },

            new() { YetkiKodu = "KITAP_GORUNTULE", YetkiAdi = "Kitap Görüntüleme", ModulAdi = "Kitaplar", IslemAdi = "Görüntüle" },
            new() { YetkiKodu = "KITAP_EKLE", YetkiAdi = "Kitap Ekleme", ModulAdi = "Kitaplar", IslemAdi = "Ekle" },
            new() { YetkiKodu = "KITAP_DUZENLE", YetkiAdi = "Kitap Düzenleme", ModulAdi = "Kitaplar", IslemAdi = "Düzenle" },
            new() { YetkiKodu = "KITAP_SIL", YetkiAdi = "Kitap Silme", ModulAdi = "Kitaplar", IslemAdi = "Sil" },

            new() { YetkiKodu = "YAZAR_GORUNTULE", YetkiAdi = "Yazar Görüntüleme", ModulAdi = "Yazarlar", IslemAdi = "Görüntüle" },
            new() { YetkiKodu = "YAZAR_EKLE", YetkiAdi = "Yazar Ekleme", ModulAdi = "Yazarlar", IslemAdi = "Ekle" },
            new() { YetkiKodu = "YAZAR_DUZENLE", YetkiAdi = "Yazar Düzenleme", ModulAdi = "Yazarlar", IslemAdi = "Düzenle" },
            new() { YetkiKodu = "YAZAR_SIL", YetkiAdi = "Yazar Silme", ModulAdi = "Yazarlar", IslemAdi = "Sil" },

            new() { YetkiKodu = "UYE_GORUNTULE", YetkiAdi = "Üye Görüntüleme", ModulAdi = "Üyeler", IslemAdi = "Görüntüle" },
            new() { YetkiKodu = "UYE_EKLE", YetkiAdi = "Üye Ekleme", ModulAdi = "Üyeler", IslemAdi = "Ekle" },
            new() { YetkiKodu = "UYE_DUZENLE", YetkiAdi = "Üye Düzenleme", ModulAdi = "Üyeler", IslemAdi = "Düzenle" },
            new() { YetkiKodu = "UYE_SIL", YetkiAdi = "Üye Silme", ModulAdi = "Üyeler", IslemAdi = "Sil" },

            new() { YetkiKodu = "ODUNC_GORUNTULE", YetkiAdi = "Ödünç Görüntüleme", ModulAdi = "Ödünç İşlemleri", IslemAdi = "Görüntüle" },
            new() { YetkiKodu = "ODUNC_VER", YetkiAdi = "Ödünç Verme", ModulAdi = "Ödünç İşlemleri", IslemAdi = "Ödünç Ver" },
            new() { YetkiKodu = "IADE_AL", YetkiAdi = "İade Alma", ModulAdi = "Ödünç İşlemleri", IslemAdi = "İade Al" },
            new() { YetkiKodu = "SURE_UZAT", YetkiAdi = "Süre Uzatma", ModulAdi = "Ödünç İşlemleri", IslemAdi = "Süre Uzat" },

            new() { YetkiKodu = "RAPOR_GORUNTULE", YetkiAdi = "Rapor Görüntüleme", ModulAdi = "Raporlar", IslemAdi = "Görüntüle" },
            new() { YetkiKodu = "RAPOR_YAZDIR", YetkiAdi = "Rapor Yazdırma", ModulAdi = "Raporlar", IslemAdi = "Yazdır" },
            new() { YetkiKodu = "RAPOR_DISA_AKTAR", YetkiAdi = "Rapor Dışa Aktarma", ModulAdi = "Raporlar", IslemAdi = "Dışa Aktar" },

            new() { YetkiKodu = "AYAR_GORUNTULE", YetkiAdi = "Ayar Görüntüleme", ModulAdi = "Ayarlar", IslemAdi = "Görüntüle" },
            new() { YetkiKodu = "AYAR_DUZENLE", YetkiAdi = "Ayar Düzenleme", ModulAdi = "Ayarlar", IslemAdi = "Düzenle" },

            new() { YetkiKodu = "KULLANICI_GORUNTULE", YetkiAdi = "Kullanıcı Görüntüleme", ModulAdi = "Kullanıcı Yönetimi", IslemAdi = "Görüntüle" },
            new() { YetkiKodu = "KULLANICI_EKLE", YetkiAdi = "Kullanıcı Ekleme", ModulAdi = "Kullanıcı Yönetimi", IslemAdi = "Ekle" },
            new() { YetkiKodu = "KULLANICI_DUZENLE", YetkiAdi = "Kullanıcı Düzenleme", ModulAdi = "Kullanıcı Yönetimi", IslemAdi = "Düzenle" },
            new() { YetkiKodu = "KULLANICI_SIL", YetkiAdi = "Kullanıcı Silme", ModulAdi = "Kullanıcı Yönetimi", IslemAdi = "Sil" },

            new() { YetkiKodu = "ROL_YETKI_YONET", YetkiAdi = "Rol ve Yetki Yönetimi", ModulAdi = "Yetkilendirme", IslemAdi = "Yönet" }
        };

        foreach (var yetki in yetkiler)
        {
            var exists = await context.Yetkiler.AnyAsync(x => x.YetkiKodu == yetki.YetkiKodu);

            if (!exists)
            {
                await context.Yetkiler.AddAsync(yetki);
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedAdminKullaniciAsync(AppDbContext context)
    {
        var adminExists = await context.Kullanicilar.AnyAsync(x => x.KullaniciAdi == "admin");

        if (!adminExists)
        {
            var admin = new Kullanici
            {
                KullaniciAdi = "admin",
                SifreHash = HashPassword("Admin123*"),
                Ad = "Sistem",
                Soyad = "Yöneticisi",
                Eposta = "admin@nexkutuphane.local",
                Telefon = null,
                AktifMi = true
            };

            await context.Kullanicilar.AddAsync(admin);
            await context.SaveChangesAsync();
        }

        var adminUser = await context.Kullanicilar.FirstAsync(x => x.KullaniciAdi == "admin");
        var adminRole = await context.Roller.FirstAsync(x => x.RolKodu == "ADMIN");

        var relationExists = await context.KullaniciRolleri
            .AnyAsync(x => x.KullaniciId == adminUser.Id && x.RolId == adminRole.Id);

        if (!relationExists)
        {
            await context.KullaniciRolleri.AddAsync(new KullaniciRol
            {
                KullaniciId = adminUser.Id,
                RolId = adminRole.Id
            });

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedAdminYetkileriAsync(AppDbContext context)
    {
        var adminRole = await context.Roller.FirstAsync(x => x.RolKodu == "ADMIN");
        var yetkiler = await context.Yetkiler.ToListAsync();

        foreach (var yetki in yetkiler)
        {
            var exists = await context.RolYetkileri
                .AnyAsync(x => x.RolId == adminRole.Id && x.YetkiId == yetki.Id);

            if (!exists)
            {
                await context.RolYetkileri.AddAsync(new RolYetki
                {
                    RolId = adminRole.Id,
                    YetkiId = yetki.Id
                });
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedDillerAsync(AppDbContext context)
    {
        var diller = new List<Dil>
        {
            new() { DilAdi = "Türkçe", DilKodu = "TR" },
            new() { DilAdi = "İngilizce", DilKodu = "EN" },
            new() { DilAdi = "Almanca", DilKodu = "DE" },
            new() { DilAdi = "Fransızca", DilKodu = "FR" },
            new() { DilAdi = "Arapça", DilKodu = "AR" }
        };

        foreach (var dil in diller)
        {
            var exists = await context.Diller.AnyAsync(x => x.DilAdi == dil.DilAdi);

            if (!exists)
            {
                await context.Diller.AddAsync(dil);
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedKategorilerAsync(AppDbContext context)
    {
        var kategoriler = new List<Kategori>
        {
            new() { KategoriAdi = "Roman", KategoriKodu = "ROMAN", Aciklama = "Roman türündeki kitaplar." },
            new() { KategoriAdi = "Hikaye", KategoriKodu = "HIKAYE", Aciklama = "Hikaye ve kısa öykü kitapları." },
            new() { KategoriAdi = "Tarih", KategoriKodu = "TARIH", Aciklama = "Tarih konulu kitaplar." },
            new() { KategoriAdi = "Bilim", KategoriKodu = "BILIM", Aciklama = "Bilimsel içerikli kitaplar." },
            new() { KategoriAdi = "Teknoloji", KategoriKodu = "TEKNOLOJI", Aciklama = "Teknoloji ve bilişim kitapları." },
            new() { KategoriAdi = "Çocuk Kitapları", KategoriKodu = "COCUK", Aciklama = "Çocuklara yönelik kitaplar." },
            new() { KategoriAdi = "Ders Kitapları", KategoriKodu = "DERS", Aciklama = "Okul derslerine yardımcı kitaplar." }
        };

        foreach (var kategori in kategoriler)
        {
            var exists = await context.Kategoriler.AnyAsync(x => x.KategoriKodu == kategori.KategoriKodu);

            if (!exists)
            {
                await context.Kategoriler.AddAsync(kategori);
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedYayinevleriAsync(AppDbContext context)
    {
        var yayinevleri = new List<Yayinevi>
        {
            new() { YayineviAdi = "Can Yayınları", Eposta = "bilgi@canyayinlari.local", WebSitesi = "https://www.canyayinlari.com" },
            new() { YayineviAdi = "Yapı Kredi Yayınları", Eposta = "bilgi@yky.local", WebSitesi = "https://www.ykykultur.com.tr" },
            new() { YayineviAdi = "İş Bankası Kültür Yayınları", Eposta = "bilgi@isbankasikulturyayinlari.local" },
            new() { YayineviAdi = "Pegasus Yayınları", Eposta = "bilgi@pegasus.local" },
            new() { YayineviAdi = "TÜBİTAK Yayınları", Eposta = "bilgi@tubitak.local" }
        };

        foreach (var yayinevi in yayinevleri)
        {
            var exists = await context.Yayinevleri.AnyAsync(x => x.YayineviAdi == yayinevi.YayineviAdi);

            if (!exists)
            {
                await context.Yayinevleri.AddAsync(yayinevi);
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedYazarlarAsync(AppDbContext context)
    {
        var yazarlar = new List<Yazar>
        {
            new()
            {
                Ad = "Mustafa Kemal",
                Soyad = "Atatürk",
                Ulke = "Türkiye",
                Biyografi = "Türkiye Cumhuriyeti'nin kurucusu ve Nutuk adlı eserin yazarıdır."
            },
            new()
            {
                Ad = "Sabahattin",
                Soyad = "Ali",
                Ulke = "Türkiye",
                Biyografi = "Türk edebiyatının önemli roman ve hikaye yazarlarındandır."
            },
            new()
            {
                Ad = "Yaşar",
                Soyad = "Kemal",
                Ulke = "Türkiye",
                Biyografi = "Türk edebiyatının önemli roman yazarlarındandır."
            },
            new()
            {
                Ad = "George",
                Soyad = "Orwell",
                Ulke = "İngiltere",
                Biyografi = "Distopik romanlarıyla tanınan İngiliz yazardır."
            },
            new()
            {
                Ad = "Jules",
                Soyad = "Verne",
                Ulke = "Fransa",
                Biyografi = "Bilim kurgu ve macera türündeki eserleriyle tanınır."
            }
        };

        foreach (var yazar in yazarlar)
        {
            var exists = await context.Yazarlar
                .AnyAsync(x => x.Ad == yazar.Ad && x.Soyad == yazar.Soyad);

            if (!exists)
            {
                await context.Yazarlar.AddAsync(yazar);
            }
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedKitaplarAsync(AppDbContext context)
    {
        var turkce = await context.Diller.FirstAsync(x => x.DilKodu == "TR");
        var ingilizce = await context.Diller.FirstAsync(x => x.DilKodu == "EN");
        var fransizca = await context.Diller.FirstAsync(x => x.DilKodu == "FR");

        var roman = await context.Kategoriler.FirstAsync(x => x.KategoriKodu == "ROMAN");
        var tarih = await context.Kategoriler.FirstAsync(x => x.KategoriKodu == "TARIH");
        var bilim = await context.Kategoriler.FirstAsync(x => x.KategoriKodu == "BILIM");

        var isBankasi = await context.Yayinevleri.FirstAsync(x => x.YayineviAdi == "İş Bankası Kültür Yayınları");
        var can = await context.Yayinevleri.FirstAsync(x => x.YayineviAdi == "Can Yayınları");
        var tubitak = await context.Yayinevleri.FirstAsync(x => x.YayineviAdi == "TÜBİTAK Yayınları");

        await AddKitapIfNotExistsAsync(context, new Kitap
        {
            KitapAdi = "Nutuk",
            Barkod = "9780000000001",
            DemirbasNo = "DMR-0001",
            ISBN = "9780000000001",
            YayinYili = 1927,
            BaskiYili = 2024,
            SayfaSayisi = 640,
            StokAdedi = 5,
            Durum = KitapDurumu.Musait,
            YayineviId = isBankasi.Id,
            KategoriId = tarih.Id,
            OrijinalDilId = turkce.Id,
            CeviriMi = false,
            Aciklama = "Okul kütüphanesi için temel tarih kitabı."
        });

        await AddKitapIfNotExistsAsync(context, new Kitap
        {
            KitapAdi = "Kürk Mantolu Madonna",
            Barkod = "9780000000002",
            DemirbasNo = "DMR-0002",
            ISBN = "9780000000002",
            YayinYili = 1943,
            BaskiYili = 2024,
            SayfaSayisi = 160,
            StokAdedi = 4,
            Durum = KitapDurumu.Musait,
            YayineviId = can.Id,
            KategoriId = roman.Id,
            OrijinalDilId = turkce.Id,
            CeviriMi = false,
            Aciklama = "Türk edebiyatının önemli romanlarından biridir."
        });

        await AddKitapIfNotExistsAsync(context, new Kitap
        {
            KitapAdi = "İnce Memed",
            Barkod = "9780000000003",
            DemirbasNo = "DMR-0003",
            ISBN = "9780000000003",
            YayinYili = 1955,
            BaskiYili = 2024,
            SayfaSayisi = 450,
            StokAdedi = 3,
            Durum = KitapDurumu.Musait,
            YayineviId = can.Id,
            KategoriId = roman.Id,
            OrijinalDilId = turkce.Id,
            CeviriMi = false,
            Aciklama = "Türk edebiyatının klasik eserlerinden biridir."
        });

        await AddKitapIfNotExistsAsync(context, new Kitap
        {
            KitapAdi = "1984",
            Barkod = "9780000000004",
            DemirbasNo = "DMR-0004",
            ISBN = "9780000000004",
            YayinYili = 1949,
            BaskiYili = 2024,
            SayfaSayisi = 352,
            StokAdedi = 6,
            Durum = KitapDurumu.Musait,
            YayineviId = can.Id,
            KategoriId = roman.Id,
            OrijinalDilId = ingilizce.Id,
            CeviriDilId = turkce.Id,
            CeviriMi = true,
            CevirmenAdi = "Örnek Çevirmen",
            Aciklama = "Çeviri roman örneği."
        });

        await AddKitapIfNotExistsAsync(context, new Kitap
        {
            KitapAdi = "Denizler Altında Yirmi Bin Fersah",
            Barkod = "9780000000005",
            DemirbasNo = "DMR-0005",
            ISBN = "9780000000005",
            YayinYili = 1870,
            BaskiYili = 2024,
            SayfaSayisi = 320,
            StokAdedi = 3,
            Durum = KitapDurumu.Musait,
            YayineviId = tubitak.Id,
            KategoriId = bilim.Id,
            OrijinalDilId = fransizca.Id,
            CeviriDilId = turkce.Id,
            CeviriMi = true,
            CevirmenAdi = "Örnek Çevirmen",
            Aciklama = "Bilim kurgu ve macera türünde örnek kitap."
        });

        await context.SaveChangesAsync();

        await AddKitapYazarIfNotExistsAsync(context, "Nutuk", "Mustafa Kemal", "Atatürk");
        await AddKitapYazarIfNotExistsAsync(context, "Kürk Mantolu Madonna", "Sabahattin", "Ali");
        await AddKitapYazarIfNotExistsAsync(context, "İnce Memed", "Yaşar", "Kemal");
        await AddKitapYazarIfNotExistsAsync(context, "1984", "George", "Orwell");
        await AddKitapYazarIfNotExistsAsync(context, "Denizler Altında Yirmi Bin Fersah", "Jules", "Verne");
    }

    private static async Task AddKitapIfNotExistsAsync(AppDbContext context, Kitap kitap)
    {
        var exists = await context.Kitaplar.AnyAsync(x => x.Barkod == kitap.Barkod);

        if (!exists)
        {
            await context.Kitaplar.AddAsync(kitap);
        }
    }

    private static async Task AddKitapYazarIfNotExistsAsync(
        AppDbContext context,
        string kitapAdi,
        string yazarAd,
        string yazarSoyad)
    {
        var kitap = await context.Kitaplar.FirstAsync(x => x.KitapAdi == kitapAdi);
        var yazar = await context.Yazarlar.FirstAsync(x => x.Ad == yazarAd && x.Soyad == yazarSoyad);

        var exists = await context.KitapYazarlari
            .AnyAsync(x => x.KitapId == kitap.Id && x.YazarId == yazar.Id);

        if (!exists)
        {
            await context.KitapYazarlari.AddAsync(new KitapYazar
            {
                KitapId = kitap.Id,
                YazarId = yazar.Id
            });

            await context.SaveChangesAsync();
        }
    }

    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = SHA256.HashData(bytes);

        return Convert.ToHexString(hashBytes);
    }

    private static async Task SeedUyeTanimVerileriAsync(AppDbContext context)
    {
        var uyeTurleri = new List<UyeTuru>
    {
        new() { UyeTuruAdi = "Öğrenci", UyeTuruKodu = "OGRENCI", Aciklama = "Okul öğrencisi." },
        new() { UyeTuruAdi = "Öğretmen", UyeTuruKodu = "OGRETMEN", Aciklama = "Okul öğretmeni." },
        new() { UyeTuruAdi = "Personel", UyeTuruKodu = "PERSONEL", Aciklama = "Okul veya kütüphane personeli." },
        new() { UyeTuruAdi = "Dış Üye", UyeTuruKodu = "DIS_UYE", Aciklama = "Bağımsız kütüphane üyesi." }
    };

        foreach (var uyeTuru in uyeTurleri)
        {
            if (!await context.UyeTurleri.AnyAsync(x => x.UyeTuruKodu == uyeTuru.UyeTuruKodu))
            {
                await context.UyeTurleri.AddAsync(uyeTuru);
            }
        }

        var siniflar = new List<Sinif>
    {
        new() { SinifAdi = "9", Seviye = 9 },
        new() { SinifAdi = "10", Seviye = 10 },
        new() { SinifAdi = "11", Seviye = 11 },
        new() { SinifAdi = "12", Seviye = 12 }
    };

        foreach (var sinif in siniflar)
        {
            if (!await context.Siniflar.AnyAsync(x => x.SinifAdi == sinif.SinifAdi))
            {
                await context.Siniflar.AddAsync(sinif);
            }
        }

        var subeler = new List<Sube>
    {
        new() { SubeAdi = "A" },
        new() { SubeAdi = "B" },
        new() { SubeAdi = "C" },
        new() { SubeAdi = "D" },
        new() { SubeAdi = "E" },
        new() { SubeAdi = "F" },
        new() { SubeAdi = "G" },
        new() { SubeAdi = "H" },
        new() { SubeAdi = "I" },
        new() { SubeAdi = "J" },
        new() { SubeAdi = "K" },
        new() { SubeAdi = "L" },
        new() { SubeAdi = "M" },
        new() { SubeAdi = "N" },
        new() { SubeAdi = "O" },
        new() { SubeAdi = "P" },
        new() { SubeAdi = "Q" },
        new() { SubeAdi = "R" },
        new() { SubeAdi = "S" },
        new() { SubeAdi = "T" },
        new() { SubeAdi = "U" },
        new() { SubeAdi = "V" },
        new() { SubeAdi = "W" },
        new() { SubeAdi = "X" },
        new() { SubeAdi = "Y" },
        new() { SubeAdi = "Z" },
        new() { SubeAdi = "SUBESIZ" },

    };

        foreach (var sube in subeler)
        {
            if (!await context.Subeler.AnyAsync(x => x.SubeAdi == sube.SubeAdi))
            {
                await context.Subeler.AddAsync(sube);
            }
        }

        await context.SaveChangesAsync();

        var bilisim = await GetOrCreateBolumAsync(context, "Bilişim Teknolojileri");
        var elektrik = await GetOrCreateBolumAsync(context, "Elektrik-Elektronik Teknolojisi");
        var muhasebe = await GetOrCreateBolumAsync(context, "Muhasebe ve Finansman");

        await GetOrCreateAlanAsync(context, "Yazılım Geliştirme", bilisim.Id);
        await GetOrCreateAlanAsync(context, "Ağ İşletmenliği", bilisim.Id);
        await GetOrCreateAlanAsync(context, "Elektrik Tesisatları", elektrik.Id);
        await GetOrCreateAlanAsync(context, "Bilgisayarlı Muhasebe", muhasebe.Id);

        await context.SaveChangesAsync();
    }

    private static async Task<Bolum> GetOrCreateBolumAsync(AppDbContext context, string bolumAdi)
    {
        var bolum = await context.Bolumler.FirstOrDefaultAsync(x => x.BolumAdi == bolumAdi);

        if (bolum is not null)
        {
            return bolum;
        }

        bolum = new Bolum
        {
            BolumAdi = bolumAdi,
            Aciklama = $"{bolumAdi} bölümü."
        };

        await context.Bolumler.AddAsync(bolum);
        await context.SaveChangesAsync();

        return bolum;
    }

    private static async Task<Alan> GetOrCreateAlanAsync(AppDbContext context, string alanAdi, int bolumId)
    {
        var alan = await context.Alanlar.FirstOrDefaultAsync(x => x.AlanAdi == alanAdi && x.BolumId == bolumId);

        if (alan is not null)
        {
            return alan;
        }

        alan = new Alan
        {
            AlanAdi = alanAdi,
            BolumId = bolumId,
            Aciklama = $"{alanAdi} alanı."
        };

        await context.Alanlar.AddAsync(alan);
        await context.SaveChangesAsync();

        return alan;
    }

    private static async Task SeedUyelerAsync(AppDbContext context)
    {
        var ogrenciTuru = await context.UyeTurleri.FirstAsync(x => x.UyeTuruKodu == "OGRENCI");
        var ogretmenTuru = await context.UyeTurleri.FirstAsync(x => x.UyeTuruKodu == "OGRETMEN");

        var sinif12 = await context.Siniflar.FirstAsync(x => x.SinifAdi == "12");
        var subeC = await context.Subeler.FirstAsync(x => x.SubeAdi == "C");

        var bilisim = await context.Bolumler.FirstAsync(x => x.BolumAdi == "Bilişim Teknolojileri");
        var yazilim = await context.Alanlar.FirstAsync(x => x.AlanAdi == "Yazılım Geliştirme");

        var uyeler = new List<Uye>
    {
        new()
        {
            Ad = "Ahmet",
            Soyad = "Yılmaz",
            OkulNo = "1001",
            Telefon = "05550000001",
            Eposta = "ahmet.yilmaz@okul.local",
            Adres = "Samsun",
            UyeTuruId = ogrenciTuru.Id,
            SinifId = sinif12.Id,
            SubeId = subeC.Id,
            BolumId = bilisim.Id,
            AlanId = yazilim.Id,
            VeliAdSoyad = "Mehmet Yılmaz",
            VeliTelefon = "05551111111",
            VeliYakinlik = "Baba",
            Durum = NexKutuphane.Domain.Enums.UyeDurumu.Aktif,
            Aciklama = "Örnek öğrenci üye."
        },
        new()
        {
            Ad = "Zeynep",
            Soyad = "Kaya",
            OkulNo = "1002",
            Telefon = "05550000002",
            Eposta = "zeynep.kaya@okul.local",
            Adres = "Samsun",
            UyeTuruId = ogrenciTuru.Id,
            SinifId = sinif12.Id,
            SubeId = subeC.Id,
            BolumId = bilisim.Id,
            AlanId = yazilim.Id,
            VeliAdSoyad = "Ayşe Kaya",
            VeliTelefon = "05552222222",
            VeliYakinlik = "Anne",
            Durum = NexKutuphane.Domain.Enums.UyeDurumu.Aktif,
            Aciklama = "Örnek öğrenci üye."
        },
        new()
        {
            Ad = "Mehmet",
            Soyad = "Demir",
            Telefon = "05550000003",
            Eposta = "mehmet.demir@okul.local",
            Adres = "Samsun",
            UyeTuruId = ogretmenTuru.Id,
            Durum = NexKutuphane.Domain.Enums.UyeDurumu.Aktif,
            Aciklama = "Örnek öğretmen üye."
        }
    };

        foreach (var uye in uyeler)
        {
            var exists = !string.IsNullOrWhiteSpace(uye.OkulNo)
                ? await context.Uyeler.AnyAsync(x => x.OkulNo == uye.OkulNo)
                : await context.Uyeler.AnyAsync(x => x.Ad == uye.Ad && x.Soyad == uye.Soyad && x.Eposta == uye.Eposta);

            if (!exists)
            {
                await context.Uyeler.AddAsync(uye);
            }
        }

        await context.SaveChangesAsync();
    }
}