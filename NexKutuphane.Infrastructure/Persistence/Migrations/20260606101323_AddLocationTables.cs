using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexKutuphane.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YerlesimBolumleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumKodu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YerlesimBolumleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dolaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DolapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DolapKodu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YerlesimBolumuId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dolaplar_YerlesimBolumleri_YerlesimBolumuId",
                        column: x => x.YerlesimBolumuId,
                        principalTable: "YerlesimBolumleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Raflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RafAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RafKodu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SiraNo = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DolapId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raflar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raflar_Dolaplar_DolapId",
                        column: x => x.DolapId,
                        principalTable: "Dolaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KitapKonumlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    RafId = table.Column<int>(type: "int", nullable: false),
                    KonumKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapKonumlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitapKonumlari_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapKonumlari_Raflar_RafId",
                        column: x => x.RafId,
                        principalTable: "Raflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dolaplar_DolapKodu",
                table: "Dolaplar",
                column: "DolapKodu",
                unique: true,
                filter: "[DolapKodu] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dolaplar_YerlesimBolumuId",
                table: "Dolaplar",
                column: "YerlesimBolumuId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKonumlari_KitapId_RafId",
                table: "KitapKonumlari",
                columns: new[] { "KitapId", "RafId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KitapKonumlari_RafId",
                table: "KitapKonumlari",
                column: "RafId");

            migrationBuilder.CreateIndex(
                name: "IX_Raflar_DolapId",
                table: "Raflar",
                column: "DolapId");

            migrationBuilder.CreateIndex(
                name: "IX_Raflar_RafKodu",
                table: "Raflar",
                column: "RafKodu",
                unique: true,
                filter: "[RafKodu] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_YerlesimBolumleri_BolumKodu",
                table: "YerlesimBolumleri",
                column: "BolumKodu",
                unique: true,
                filter: "[BolumKodu] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapKonumlari");

            migrationBuilder.DropTable(
                name: "Raflar");

            migrationBuilder.DropTable(
                name: "Dolaplar");

            migrationBuilder.DropTable(
                name: "YerlesimBolumleri");
        }
    }
}
