using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfos_DoiTuongs_MaDoiTuong",
                table: "StudentInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfos_KhuVucs_KhuVucId",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_KhuVucId",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaDoiTuong",
                table: "StudentInfos");

            migrationBuilder.RenameColumn(
                name: "MaDoiTuong",
                table: "StudentInfos",
                newName: "MaKhuVucId");

            migrationBuilder.RenameColumn(
                name: "KhuVucId",
                table: "StudentInfos",
                newName: "MaDoiTuongId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_MaDoiTuongId",
                table: "StudentInfos",
                column: "MaDoiTuongId",
                unique: true,
                filter: "[MaDoiTuongId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_MaKhuVucId",
                table: "StudentInfos",
                column: "MaKhuVucId",
                unique: true,
                filter: "[MaKhuVucId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfos_DoiTuongs_MaDoiTuongId",
                table: "StudentInfos",
                column: "MaDoiTuongId",
                principalTable: "DoiTuongs",
                principalColumn: "MaDoiTuong",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfos_KhuVucs_MaKhuVucId",
                table: "StudentInfos",
                column: "MaKhuVucId",
                principalTable: "KhuVucs",
                principalColumn: "MaKhuVuc",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfos_DoiTuongs_MaDoiTuongId",
                table: "StudentInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfos_KhuVucs_MaKhuVucId",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaDoiTuongId",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaKhuVucId",
                table: "StudentInfos");

            migrationBuilder.RenameColumn(
                name: "MaKhuVucId",
                table: "StudentInfos",
                newName: "MaDoiTuong");

            migrationBuilder.RenameColumn(
                name: "MaDoiTuongId",
                table: "StudentInfos",
                newName: "KhuVucId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_KhuVucId",
                table: "StudentInfos",
                column: "KhuVucId",
                unique: true,
                filter: "[KhuVucId] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfos_KhuVucs_KhuVucId",
                table: "StudentInfos",
                column: "KhuVucId",
                principalTable: "KhuVucs",
                principalColumn: "MaKhuVuc",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
