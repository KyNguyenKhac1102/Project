using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNguyenVongs_Nganhs_NganhId",
                table: "StudentNguyenVongs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNguyenVongs_ToHops_ToHopId",
                table: "StudentNguyenVongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToHops",
                table: "ToHops");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_NganhId",
                table: "StudentNguyenVongs");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_ToHopId",
                table: "StudentNguyenVongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nganhs",
                table: "Nganhs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ToHops");

            migrationBuilder.DropColumn(
                name: "NganhId",
                table: "StudentNguyenVongs");

            migrationBuilder.DropColumn(
                name: "ToHopId",
                table: "StudentNguyenVongs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Nganhs");

            migrationBuilder.AddColumn<string>(
                name: "MaToHop",
                table: "ToHops",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaNganh",
                table: "StudentNguyenVongs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaToHop",
                table: "StudentNguyenVongs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNganh",
                table: "Nganhs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToHops",
                table: "ToHops",
                column: "MaToHop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nganhs",
                table: "Nganhs",
                column: "MaNganh");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToHops",
                table: "ToHops");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_MaNganh",
                table: "StudentNguyenVongs");

            migrationBuilder.DropIndex(
                name: "IX_StudentNguyenVongs_MaToHop",
                table: "StudentNguyenVongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nganhs",
                table: "Nganhs");

            migrationBuilder.DropColumn(
                name: "MaToHop",
                table: "ToHops");

            migrationBuilder.DropColumn(
                name: "MaNganh",
                table: "StudentNguyenVongs");

            migrationBuilder.DropColumn(
                name: "MaToHop",
                table: "StudentNguyenVongs");

            migrationBuilder.DropColumn(
                name: "MaNganh",
                table: "Nganhs");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ToHops",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "NganhId",
                table: "StudentNguyenVongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToHopId",
                table: "StudentNguyenVongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Nganhs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToHops",
                table: "ToHops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nganhs",
                table: "Nganhs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_NganhId",
                table: "StudentNguyenVongs",
                column: "NganhId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_ToHopId",
                table: "StudentNguyenVongs",
                column: "ToHopId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNguyenVongs_Nganhs_NganhId",
                table: "StudentNguyenVongs",
                column: "NganhId",
                principalTable: "Nganhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNguyenVongs_ToHops_ToHopId",
                table: "StudentNguyenVongs",
                column: "ToHopId",
                principalTable: "ToHops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
