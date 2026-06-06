using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexKutuphane.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslem_KitapKopyalari_KitapKopyaId",
                table: "OduncIslem");

            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslem_Kullanicilar_IadeAlanKullaniciId",
                table: "OduncIslem");

            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslem_Kullanicilar_OduncVerenKullaniciId",
                table: "OduncIslem");

            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslem_Uyeler_UyeId",
                table: "OduncIslem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OduncIslem",
                table: "OduncIslem");

            migrationBuilder.RenameTable(
                name: "OduncIslem",
                newName: "OduncIslemleri");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslem_UyeId",
                table: "OduncIslemleri",
                newName: "IX_OduncIslemleri_UyeId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslem_OduncVerenKullaniciId",
                table: "OduncIslemleri",
                newName: "IX_OduncIslemleri_OduncVerenKullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslem_KitapKopyaId",
                table: "OduncIslemleri",
                newName: "IX_OduncIslemleri_KitapKopyaId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslem_IadeAlanKullaniciId",
                table: "OduncIslemleri",
                newName: "IX_OduncIslemleri_IadeAlanKullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslem_Durum",
                table: "OduncIslemleri",
                newName: "IX_OduncIslemleri_Durum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OduncIslemleri",
                table: "OduncIslemleri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslemleri_KitapKopyalari_KitapKopyaId",
                table: "OduncIslemleri",
                column: "KitapKopyaId",
                principalTable: "KitapKopyalari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslemleri_Kullanicilar_IadeAlanKullaniciId",
                table: "OduncIslemleri",
                column: "IadeAlanKullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslemleri_Kullanicilar_OduncVerenKullaniciId",
                table: "OduncIslemleri",
                column: "OduncVerenKullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslemleri_Uyeler_UyeId",
                table: "OduncIslemleri",
                column: "UyeId",
                principalTable: "Uyeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslemleri_KitapKopyalari_KitapKopyaId",
                table: "OduncIslemleri");

            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslemleri_Kullanicilar_IadeAlanKullaniciId",
                table: "OduncIslemleri");

            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslemleri_Kullanicilar_OduncVerenKullaniciId",
                table: "OduncIslemleri");

            migrationBuilder.DropForeignKey(
                name: "FK_OduncIslemleri_Uyeler_UyeId",
                table: "OduncIslemleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OduncIslemleri",
                table: "OduncIslemleri");

            migrationBuilder.RenameTable(
                name: "OduncIslemleri",
                newName: "OduncIslem");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslemleri_UyeId",
                table: "OduncIslem",
                newName: "IX_OduncIslem_UyeId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslemleri_OduncVerenKullaniciId",
                table: "OduncIslem",
                newName: "IX_OduncIslem_OduncVerenKullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslemleri_KitapKopyaId",
                table: "OduncIslem",
                newName: "IX_OduncIslem_KitapKopyaId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslemleri_IadeAlanKullaniciId",
                table: "OduncIslem",
                newName: "IX_OduncIslem_IadeAlanKullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_OduncIslemleri_Durum",
                table: "OduncIslem",
                newName: "IX_OduncIslem_Durum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OduncIslem",
                table: "OduncIslem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslem_KitapKopyalari_KitapKopyaId",
                table: "OduncIslem",
                column: "KitapKopyaId",
                principalTable: "KitapKopyalari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslem_Kullanicilar_IadeAlanKullaniciId",
                table: "OduncIslem",
                column: "IadeAlanKullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslem_Kullanicilar_OduncVerenKullaniciId",
                table: "OduncIslem",
                column: "OduncVerenKullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OduncIslem_Uyeler_UyeId",
                table: "OduncIslem",
                column: "UyeId",
                principalTable: "Uyeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
