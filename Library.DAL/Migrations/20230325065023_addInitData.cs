using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Isbn", "Name", "ReceiptTime", "ReturnTime" },
                values: new object[,]
                {
                    { 1, "Amor Towles", "This is a historical fiction novel that follows four young men on a cross-country road trip in 1950s America. Along the way, they encounter adventure, danger, and unexpected connections.", "historical fiction", "978-0-7352-1128-5", "The Lincoln Highway", null, null },
                    { 2, "Frank Herbert", "This is a science fiction classic that tells the story of Paul Atreides, a young man who inherits a desert planet called Arrakis, which holds a valuable spice that can extend life and enhance consciousness. Paul must fight against enemies who want to take over his planet and his destiny.", "science fiction", "978-0-4417-8644-5", "Dune", null, null },
                    { 3, "James Clear", "This is a self-help book that teaches readers how to create and maintain effective habits that can improve their lives. The book draws on scientific research, personal stories, and practical advice.", "self-help", "978-0-7352-1049-3", "Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Nickname", "Password" },
                values: new object[] { 1, "user", "E24FECBB80B33722CDFF42A63635555F2E1EAB5AC9F7FB28BA07F61A3D29DF27:D0AB4E3D13A15CE460D6D7AD14E7DBAD" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
