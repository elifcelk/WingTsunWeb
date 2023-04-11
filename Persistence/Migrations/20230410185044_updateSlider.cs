using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sliders",
                schema: "public",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                schema: "public",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                schema: "public",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Lang",
                schema: "public",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "LinkTitle",
                schema: "public",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "LinkUrl",
                schema: "public",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SliderOrder",
                schema: "public",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "SubTitle",
                schema: "public",
                table: "Sliders",
                newName: "ImageURL");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "public",
                table: "Sliders",
                type: "character varying",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "Sliders",
                type: "character varying",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                schema: "public",
                table: "Sliders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Sliders",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slider_Id",
                schema: "public",
                table: "Sliders",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Slider_Id",
                schema: "public",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                schema: "public",
                table: "Sliders",
                newName: "SubTitle");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "public",
                table: "Sliders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "Sliders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                schema: "public",
                table: "Sliders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Sliders",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                schema: "public",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                schema: "public",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                schema: "public",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkTitle",
                schema: "public",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                schema: "public",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SliderOrder",
                schema: "public",
                table: "Sliders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sliders",
                schema: "public",
                table: "Sliders",
                column: "Id");
        }
    }
}
