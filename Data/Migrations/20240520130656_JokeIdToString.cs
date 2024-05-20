using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuckNorrisJokeGenerator.Data.Migrations
{
    /// <inheritdoc />
    public partial class JokeIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteJokes");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Jokes",
                newName: "Value");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Jokes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Jokes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Jokes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Jokes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Jokes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Jokes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Jokes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Jokes");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Jokes",
                newName: "Content");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Jokes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "FavoriteJokes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteJokes", x => x.Id);
                });
        }
    }
}
