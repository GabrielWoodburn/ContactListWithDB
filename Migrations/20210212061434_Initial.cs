using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsListDBWoodburn.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    CommentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Name" },
                values: new object[,]
                {
                    { "A", "Family" },
                    { "B", "Work" },
                    { "C", "Friend" },
                    { "D", "Technical" },
                    { "E", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "CommentId", "Name", "PhoneNumber" },
                values: new object[] { 2, "100 Main Avenue", "A", "Wonder Woman", "555-5555" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "CommentId", "Name", "PhoneNumber" },
                values: new object[] { 4, "100 Main Avenue", "D", "Casablanca", "555-5555" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "CommentId", "Name", "PhoneNumber" },
                values: new object[] { 3, "100 Main Avenue", "E", "Moonstruck", "555-5555" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CommentId",
                table: "Contacts",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
