using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNguyenVongs_Nganhs_NganhMaNganh",
                table: "StudentNguyenVongs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNguyenVongs_ToHops_ToHopMaToHop",
                table: "StudentNguyenVongs");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_NganhMaNganh",
                table: "StudentNguyenVongs");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_ToHopMaToHop",
                table: "StudentNguyenVongs");

            migrationBuilder.DropColumn(
                name: "NganhMaNganh",
                table: "StudentNguyenVongs");

            migrationBuilder.DropColumn(
                name: "ToHopMaToHop",
                table: "StudentNguyenVongs");

            migrationBuilder.AlterColumn<string>(
                name: "MaToHop",
                table: "StudentNguyenVongs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNganh",
                table: "StudentNguyenVongs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_MaNganh",
                table: "StudentNguyenVongs",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_MaToHop",
                table: "StudentNguyenVongs",
                column: "MaToHop");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNguyenVongs_Nganhs_MaNganh",
                table: "StudentNguyenVongs",
                column: "MaNganh",
                principalTable: "Nganhs",
                principalColumn: "MaNganh",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNguyenVongs_ToHops_MaToHop",
                table: "StudentNguyenVongs",
                column: "MaToHop",
                principalTable: "ToHops",
                principalColumn: "MaToHop",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNguyenVongs_Nganhs_MaNganh",
                table: "StudentNguyenVongs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNguyenVongs_ToHops_MaToHop",
                table: "StudentNguyenVongs");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_MaNganh",
                table: "StudentNguyenVongs");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_MaToHop",
                table: "StudentNguyenVongs");

            migrationBuilder.AlterColumn<string>(
                name: "MaToHop",
                table: "StudentNguyenVongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNganh",
                table: "StudentNguyenVongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NganhMaNganh",
                table: "StudentNguyenVongs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToHopMaToHop",
                table: "StudentNguyenVongs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_NganhMaNganh",
                table: "StudentNguyenVongs",
                column: "NganhMaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_ToHopMaToHop",
                table: "StudentNguyenVongs",
                column: "ToHopMaToHop");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNguyenVongs_Nganhs_NganhMaNganh",
                table: "StudentNguyenVongs",
                column: "NganhMaNganh",
                principalTable: "Nganhs",
                principalColumn: "MaNganh",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNguyenVongs_ToHops_ToHopMaToHop",
                table: "StudentNguyenVongs",
                column: "ToHopMaToHop",
                principalTable: "ToHops",
                principalColumn: "MaToHop",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
