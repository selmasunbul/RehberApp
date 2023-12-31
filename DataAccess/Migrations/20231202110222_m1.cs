﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BilgiTipi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Adı = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilgiTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Adı = table.Column<string>(type: "text", nullable: false),
                    SoyAdi = table.Column<string>(type: "text", nullable: false),
                    Firma = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İletisimBilgisi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BilgiTipiId = table.Column<Guid>(type: "uuid", nullable: false),
                    KisiId = table.Column<Guid>(type: "uuid", nullable: false),
                    İcerik = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İletisimBilgisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İletisimBilgisi_BilgiTipi_BilgiTipiId",
                        column: x => x.BilgiTipiId,
                        principalTable: "BilgiTipi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_İletisimBilgisi_Kisi_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_İletisimBilgisi_BilgiTipiId",
                table: "İletisimBilgisi",
                column: "BilgiTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_İletisimBilgisi_KisiId",
                table: "İletisimBilgisi",
                column: "KisiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İletisimBilgisi");

            migrationBuilder.DropTable(
                name: "BilgiTipi");

            migrationBuilder.DropTable(
                name: "Kisi");
        }
    }
}
