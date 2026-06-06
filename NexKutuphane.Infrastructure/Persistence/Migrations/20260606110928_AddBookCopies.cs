using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexKutuphane.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBookCopies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KitapKopyalari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DemirbasNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    RafId = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapKopyalari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitapKopyalari_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KitapKopyalari_Raflar_RafId",
                        column: x => x.RafId,
                        principalTable: "Raflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapKopyalari_Barkod",
                table: "KitapKopyalari",
                column: "Barkod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KitapKopyalari_DemirbasNo",
                table: "KitapKopyalari",
                column: "DemirbasNo",
                unique: true,
                filter: "[DemirbasNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKopyalari_KitapId",
                table: "KitapKopyalari",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKopyalari_RafId",
                table: "KitapKopyalari",
                column: "RafId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapKopyalari");
        }
    }
}
