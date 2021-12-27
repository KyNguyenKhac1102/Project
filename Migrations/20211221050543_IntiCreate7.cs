using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KhoaId",
                table: "Nganhs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nganhs_KhoaId",
                table: "Nganhs",
                column: "KhoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nganhs_Khoas_KhoaId",
                table: "Nganhs",
                column: "KhoaId",
                principalTable: "Khoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nganhs_Khoas_KhoaId",
                table: "Nganhs");

            migrationBuilder.DropTable(
                name: "Khoas");

            migrationBuilder.DropIndex(
                name: "IX_Nganhs_KhoaId",
                table: "Nganhs");

            migrationBuilder.DropColumn(
                name: "KhoaId",
                table: "Nganhs");
        }
    }
}
