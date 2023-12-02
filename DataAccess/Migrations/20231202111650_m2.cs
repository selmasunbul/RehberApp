using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İletisimBilgisi_Kisi_KisiId",
                table: "İletisimBilgisi");

            migrationBuilder.DropTable(
                name: "Kisi");

            migrationBuilder.DropIndex(
                name: "IX_İletisimBilgisi_KisiId",
                table: "İletisimBilgisi");

            migrationBuilder.CreateTable(
                name: "Rapor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RaporDurumu = table.Column<string>(type: "text", nullable: false),
                    Konum = table.Column<string>(type: "text", nullable: false),
                    KisiSayisi = table.Column<int>(type: "integer", nullable: false),
                    TelefonNoSayisi = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapor", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapor");

            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Adı = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Firma = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SoyAdi = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_İletisimBilgisi_KisiId",
                table: "İletisimBilgisi",
                column: "KisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_İletisimBilgisi_Kisi_KisiId",
                table: "İletisimBilgisi",
                column: "KisiId",
                principalTable: "Kisi",
                principalColumn: "Id");
        }
    }
}
