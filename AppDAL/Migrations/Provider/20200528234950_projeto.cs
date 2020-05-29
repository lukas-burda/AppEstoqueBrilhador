using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDAL.Migrations.Provider
{
    public partial class projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "Providers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "telefone",
                table: "Providers");
        }
    }
}
