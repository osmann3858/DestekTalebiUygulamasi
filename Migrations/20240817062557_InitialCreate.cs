using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DestekTalebiUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestekTalepleri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "0"),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IslemYapan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oncelik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestekTalepleri", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestekTalepleri");
        }
    }
}
