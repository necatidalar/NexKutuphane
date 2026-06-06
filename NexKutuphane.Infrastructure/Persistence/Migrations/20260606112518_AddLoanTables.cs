using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexKutuphane.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OduncIslem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeId = table.Column<int>(type: "int", nullable: false),
                    KitapKopyaId = table.Column<int>(type: "int", nullable: false),
                    OduncTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    SureUzatmaSayisi = table.Column<int>(type: "int", nullable: false),
                    CezaTutari = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OduncVerenKullaniciId = table.Column<int>(type: "int", nullable: true),
                    IadeAlanKullaniciId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OduncIslem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OduncIslem_KitapKopyalari_KitapKopyaId",
                        column: x => x.KitapKopyaId,
                        principalTable: "KitapKopyalari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OduncIslem_Kullanicilar_IadeAlanKullaniciId",
                        column: x => x.IadeAlanKullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OduncIslem_Kullanicilar_OduncVerenKullaniciId",
                        column: x => x.OduncVerenKullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OduncIslem_Uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uyeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OduncIslem_Durum",
                table: "OduncIslem",
                column: "Durum");

            migrationBuilder.CreateIndex(
                name: "IX_OduncIslem_IadeAlanKullaniciId",
                table: "OduncIslem",
                column: "IadeAlanKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OduncIslem_KitapKopyaId",
                table: "OduncIslem",
                column: "KitapKopyaId");

            migrationBuilder.CreateIndex(
                name: "IX_OduncIslem_OduncVerenKullaniciId",
                table: "OduncIslem",
                column: "OduncVerenKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OduncIslem_UyeId",
                table: "OduncIslem",
                column: "UyeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OduncIslem");
        }
    }
}
