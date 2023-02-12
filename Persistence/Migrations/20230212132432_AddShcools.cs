using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddShcools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Schools",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying", maxLength: 100, nullable: false),
                    CityName = table.Column<string>(type: "character varying", maxLength: 50, nullable: false),
                    DistrictName = table.Column<string>(type: "character varying", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying", maxLength: 500, nullable: false),
                    ContactNumber = table.Column<string>(type: "character varying", maxLength: 20, nullable: false),
                    PhotoPath = table.Column<string>(type: "character varying", maxLength: 500, nullable: false),
                    InstructorName = table.Column<string>(type: "character varying", maxLength: 50, nullable: false),
                    InstructorStatus = table.Column<string>(type: "character varying", maxLength: 30, nullable: false),
                    InstructorResume = table.Column<string>(type: "character varying", maxLength: 500, nullable: false),
                    TimeTable = table.Column<string>(type: "character varying", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Id", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools",
                schema: "public");
        }
    }
}
