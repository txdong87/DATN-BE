using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "user",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "user",
                type: "int(11)",
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);
        }
    }
}
