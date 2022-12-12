using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsletterOrganizer.API.Migrations
{
    /// <inheritdoc />
    public partial class EmailProvidersSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProtocolType = table.Column<int>(type: "INTEGER", nullable: false),
                    Host = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    UseSSL = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailProvider", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmailProvider",
                columns: new[] { "Id", "Host", "Name", "Port", "ProtocolType", "UseSSL" },
                values: new object[,]
                {
                    { 1, "imap.gmail.com", "Gmail", 993, 0, true },
                    { 2, "imap.mail.yahoo.com", "Yahoo", 993, 0, true },
                    { 3, "outlook.office365.com", "Outlook - IMAP", 993, 0, true },
                    { 4, "outlook.office365.com", "Outlook - POP3", 995, 1, true },
                    { 5, "imap.mail.me.com", "iCloud", 993, 0, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailProvider");
        }
    }
}
