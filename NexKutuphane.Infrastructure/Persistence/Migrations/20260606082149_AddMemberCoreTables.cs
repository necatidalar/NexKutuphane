using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexKutuphane.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberCoreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolumler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siniflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifAdi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seviye = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubeAdi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UyeTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeTuruAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UyeTuruKodu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UyeTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlanAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolumId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alanlar_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OkulNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    UyeTuruId = table.Column<int>(type: "int", nullable: true),
                    SinifId = table.Column<int>(type: "int", nullable: true),
                    SubeId = table.Column<int>(type: "int", nullable: true),
                    BolumId = table.Column<int>(type: "int", nullable: true),
                    AlanId = table.Column<int>(type: "int", nullable: true),
                    VeliAdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeliTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeliYakinlik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uyeler_Alanlar_AlanId",
                        column: x => x.AlanId,
                        principalTable: "Alanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uyeler_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uyeler_Siniflar_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uyeler_Subeler_SubeId",
                        column: x => x.SubeId,
                        principalTable: "Subeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uyeler_UyeTurleri_UyeTuruId",
                        column: x => x.UyeTuruId,
                        principalTable: "UyeTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alanlar_BolumId",
                table: "Alanlar",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_Siniflar_SinifAdi",
                table: "Siniflar",
                column: "SinifAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subeler_SubeAdi",
                table: "Subeler",
                column: "SubeAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_AlanId",
                table: "Uyeler",
                column: "AlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_BolumId",
                table: "Uyeler",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_OkulNo",
                table: "Uyeler",
                column: "OkulNo",
                unique: true,
                filter: "[OkulNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_SinifId",
                table: "Uyeler",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_SubeId",
                table: "Uyeler",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_UyeTuruId",
                table: "Uyeler",
                column: "UyeTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_UyeTurleri_UyeTuruKodu",
                table: "UyeTurleri",
                column: "UyeTuruKodu",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uyeler");

            migrationBuilder.DropTable(
                name: "Alanlar");

            migrationBuilder.DropTable(
                name: "Siniflar");

            migrationBuilder.DropTable(
                name: "Subeler");

            migrationBuilder.DropTable(
                name: "UyeTurleri");

            migrationBuilder.DropTable(
                name: "Bolumler");
        }
    }
}
