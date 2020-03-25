using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookstore.Data.Migrations
{
    public partial class bookviewmodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Books");
        }
    }
}
