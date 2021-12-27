using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfos_DoiTuongs_DoiTuongId",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_DoiTuongId",
                table: "StudentInfos");

            migrationBuilder.RenameColumn(
                name: "DoiTuongId",
                table: "StudentInfos",
                newName: "MaDoiTuong");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_MaDoiTuong",
                table: "StudentInfos",
                column: "MaDoiTuong",
                unique: true,
                filter: "[MaDoiTuong] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfos_DoiTuongs_MaDoiTuong",
                table: "StudentInfos",
                column: "MaDoiTuong",
                principalTable: "DoiTuongs",
                principalColumn: "MaDoiTuong",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfos_DoiTuongs_MaDoiTuong",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaDoiTuong",
                table: "StudentInfos");

            migrationBuilder.RenameColumn(
                name: "MaDoiTuong",
                table: "StudentInfos",
                newName: "DoiTuongId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_DoiTuongId",
                table: "StudentInfos",
                column: "DoiTuongId",
                unique: true,
                filter: "[DoiTuongId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfos_DoiTuongs_DoiTuongId",
                table: "StudentInfos",
                column: "DoiTuongId",
                principalTable: "DoiTuongs",
                principalColumn: "MaDoiTuong",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
