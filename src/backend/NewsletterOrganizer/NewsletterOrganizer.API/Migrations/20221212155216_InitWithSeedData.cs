using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsletterOrganizer.API.Migrations
{
    /// <inheritdoc />
    public partial class InitWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageKey = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageKey);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsletterWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LanguageKey = table.Column<string>(type: "TEXT", nullable: false),
                    Word = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsletterWords_Languages_LanguageKey",
                        column: x => x.LanguageKey,
                        principalTable: "Languages",
                        principalColumn: "LanguageKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageKey", "Name" },
                values: new object[,]
                {
                    { "EN", "English" },
                    { "PL", "Polski" }
                });

            migrationBuilder.InsertData(
                table: "NewsletterWords",
                columns: new[] { "Id", "LanguageKey", "Word" },
                values: new object[,]
                {
                    { 1, "PL", "Anuluj Subskrybcję" },
                    { 2, "PL", "Wypisz" },
                    { 3, "PL", "Newsletter" },
                    { 4, "PL", "Otrzymałeś tę wiadomość" },
                    { 5, "EN", "Unsubscribe" },
                    { 6, "EN", "Newsletter" },
                    { 7, "EN", "Subscription" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAccounts_UserId",
                table: "EmailAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterWords_LanguageKey",
                table: "NewsletterWords",
                column: "LanguageKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAccounts");

            migrationBuilder.DropTable(
                name: "NewsletterWords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
