using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoiTuongs",
                columns: table => new
                {
                    MaDoiTuong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDoiTuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiTuongs", x => x.MaDoiTuong);
                });

            migrationBuilder.CreateTable(
                name: "KhuVucs",
                columns: table => new
                {
                    MaKhuVuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhuVuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuVucs", x => x.MaKhuVuc);
                });

            migrationBuilder.CreateTable(
                name: "Nganhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNganh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tinhs",
                columns: table => new
                {
                    MaTinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tinhs", x => x.MaTinh);
                });

            migrationBuilder.CreateTable(
                name: "ToHops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenToHop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToHops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTruong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenTruong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SoCCCD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChiHoKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DoiTuongId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KhuVucId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tinh10Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tinh11Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tinh12Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TruongLop10Id = table.Column<int>(type: "int", nullable: false),
                    TruongLop11Id = table.Column<int>(type: "int", nullable: false),
                    TruongLop12Id = table.Column<int>(type: "int", nullable: false),
                    DiaChiLienHe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoTenBo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SdtBo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoTenMe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SdtMe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hocba10_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Hocba11_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Hocba12_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StudentNguyenVongId = table.Column<int>(type: "int", nullable: true),
                    DiemToan10 = table.Column<double>(type: "float", nullable: false),
                    DiemLy10 = table.Column<double>(type: "float", nullable: false),
                    DiemHoa10 = table.Column<double>(type: "float", nullable: false),
                    DiemToan11 = table.Column<double>(type: "float", nullable: false),
                    DiemLy11 = table.Column<double>(type: "float", nullable: false),
                    DiemHoa11 = table.Column<double>(type: "float", nullable: false),
                    DiemToan12 = table.Column<double>(type: "float", nullable: false),
                    DiemLy12 = table.Column<double>(type: "float", nullable: false),
                    DiemHoa12 = table.Column<double>(type: "float", nullable: false),
                    DiemTb10 = table.Column<double>(type: "float", nullable: false),
                    DiemTb11 = table.Column<double>(type: "float", nullable: false),
                    DiemTb12 = table.Column<double>(type: "float", nullable: false),
                    DiemTb_UuTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInfos_DoiTuongs_DoiTuongId",
                        column: x => x.DoiTuongId,
                        principalTable: "DoiTuongs",
                        principalColumn: "MaDoiTuong",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInfos_KhuVucs_KhuVucId",
                        column: x => x.KhuVucId,
                        principalTable: "KhuVucs",
                        principalColumn: "MaKhuVuc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInfos_Tinhs_Tinh10Id",
                        column: x => x.Tinh10Id,
                        principalTable: "Tinhs",
                        principalColumn: "MaTinh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInfos_Tinhs_Tinh11Id",
                        column: x => x.Tinh11Id,
                        principalTable: "Tinhs",
                        principalColumn: "MaTinh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInfos_Tinhs_Tinh12Id",
                        column: x => x.Tinh12Id,
                        principalTable: "Tinhs",
                        principalColumn: "MaTinh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInfos_Truongs_TruongLop10Id",
                        column: x => x.TruongLop10Id,
                        principalTable: "Truongs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentInfos_Truongs_TruongLop11Id",
                        column: x => x.TruongLop11Id,
                        principalTable: "Truongs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentInfos_Truongs_TruongLop12Id",
                        column: x => x.TruongLop12Id,
                        principalTable: "Truongs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentNguyenVongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stt_NguyenVong = table.Column<int>(type: "int", nullable: true),
                    NganhId = table.Column<int>(type: "int", nullable: false),
                    ToHopId = table.Column<int>(type: "int", nullable: false),
                    StudentInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNguyenVongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentNguyenVongs_Nganhs_NganhId",
                        column: x => x.NganhId,
                        principalTable: "Nganhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentNguyenVongs_StudentInfos_StudentInfoId",
                        column: x => x.StudentInfoId,
                        principalTable: "StudentInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentNguyenVongs_ToHops_ToHopId",
                        column: x => x.ToHopId,
                        principalTable: "ToHops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentInfoId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_StudentInfos_StudentInfoId",
                        column: x => x.StudentInfoId,
                        principalTable: "StudentInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_DoiTuongId",
                table: "StudentInfos",
                column: "DoiTuongId",
                unique: true,
                filter: "[DoiTuongId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_KhuVucId",
                table: "StudentInfos",
                column: "KhuVucId",
                unique: true,
                filter: "[KhuVucId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh10Id",
                table: "StudentInfos",
                column: "Tinh10Id",
                unique: true,
                filter: "[Tinh10Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh11Id",
                table: "StudentInfos",
                column: "Tinh11Id",
                unique: true,
                filter: "[Tinh11Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh12Id",
                table: "StudentInfos",
                column: "Tinh12Id",
                unique: true,
                filter: "[Tinh12Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop10Id",
                table: "StudentInfos",
                column: "TruongLop10Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop11Id",
                table: "StudentInfos",
                column: "TruongLop11Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop12Id",
                table: "StudentInfos",
                column: "TruongLop12Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_NganhId",
                table: "StudentNguyenVongs",
                column: "NganhId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_StudentInfoId",
                table: "StudentNguyenVongs",
                column: "StudentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNguyenVongs_ToHopId",
                table: "StudentNguyenVongs",
                column: "ToHopId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentInfoId",
                table: "Users",
                column: "StudentInfoId",
                unique: true,
                filter: "[StudentInfoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentNguyenVongs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Nganhs");

            migrationBuilder.DropTable(
                name: "ToHops");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "StudentInfos");

            migrationBuilder.DropTable(
                name: "DoiTuongs");

            migrationBuilder.DropTable(
                name: "KhuVucs");

            migrationBuilder.DropTable(
                name: "Tinhs");

            migrationBuilder.DropTable(
                name: "Truongs");
        }
    }
}
