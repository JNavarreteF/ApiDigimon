using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigimon.Migrations
{
    /// <inheritdoc />
    public partial class InitialDigimonDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DIGIMONS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    HREF = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IMAGE = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIGIMONS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DIGIMONS");
        }
    }
}
