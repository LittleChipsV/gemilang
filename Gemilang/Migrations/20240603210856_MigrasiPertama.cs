using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gemilang.Migrations
{
    /// <inheritdoc />
    public partial class MigrasiPertama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mata_pelajaran",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mata_pelajaran", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "CHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mata_pelajaran_kelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMataPelajaran = table.Column<int>(type: "int", nullable: false),
                    IdKelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mata_pelajaran_kelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mata_pelajaran_kelas_Kelas_IdKelas",
                        column: x => x.IdKelas,
                        principalTable: "Kelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mata_pelajaran_kelas_mata_pelajaran_IdMataPelajaran",
                        column: x => x.IdMataPelajaran,
                        principalTable: "mata_pelajaran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guru", x => x.Id);
                    table.ForeignKey(
                        name: "FK_guru_user_Id",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "siswa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdKelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_siswa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_siswa_Kelas_IdKelas",
                        column: x => x.IdKelas,
                        principalTable: "Kelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_siswa_user_Id",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "topik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTupleMataPelajaranKelas = table.Column<int>(type: "int", nullable: false),
                    MataPelajaranId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topik_mata_pelajaran_MataPelajaranId",
                        column: x => x.MataPelajaranId,
                        principalTable: "mata_pelajaran",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_topik_mata_pelajaran_kelas_IdTupleMataPelajaranKelas",
                        column: x => x.IdTupleMataPelajaranKelas,
                        principalTable: "mata_pelajaran_kelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "data_pengajaran",
                columns: table => new
                {
                    IdGuru = table.Column<int>(type: "int", nullable: false),
                    IdTupleMataPelajaranKelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data_pengajaran", x => new { x.IdGuru, x.IdTupleMataPelajaranKelas });
                    table.ForeignKey(
                        name: "FK_data_pengajaran_guru_IdGuru",
                        column: x => x.IdGuru,
                        principalTable: "guru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_data_pengajaran_mata_pelajaran_kelas_IdTupleMataPelajaranKel~",
                        column: x => x.IdTupleMataPelajaranKelas,
                        principalTable: "mata_pelajaran_kelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nilai_siswa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nilai = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    IdSiswa = table.Column<int>(type: "int", nullable: false),
                    IdTopik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nilai_siswa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nilai_siswa_siswa_IdSiswa",
                        column: x => x.IdSiswa,
                        principalTable: "siswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nilai_siswa_topik_IdTopik",
                        column: x => x.IdTopik,
                        principalTable: "topik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "email", "password", "Role", "username" },
                values: new object[] { 1, "admin@gmail.com", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_data_pengajaran_IdTupleMataPelajaranKelas",
                table: "data_pengajaran",
                column: "IdTupleMataPelajaranKelas");

            migrationBuilder.CreateIndex(
                name: "IX_Kelas_Nama",
                table: "Kelas",
                column: "Nama",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mata_pelajaran_Nama",
                table: "mata_pelajaran",
                column: "Nama",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mata_pelajaran_kelas_IdKelas",
                table: "mata_pelajaran_kelas",
                column: "IdKelas");

            migrationBuilder.CreateIndex(
                name: "IX_mata_pelajaran_kelas_IdMataPelajaran_IdKelas",
                table: "mata_pelajaran_kelas",
                columns: new[] { "IdMataPelajaran", "IdKelas" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nilai_siswa_IdSiswa_IdTopik",
                table: "nilai_siswa",
                columns: new[] { "IdSiswa", "IdTopik" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nilai_siswa_IdTopik",
                table: "nilai_siswa",
                column: "IdTopik");

            migrationBuilder.CreateIndex(
                name: "IX_siswa_IdKelas",
                table: "siswa",
                column: "IdKelas");

            migrationBuilder.CreateIndex(
                name: "IX_topik_IdTupleMataPelajaranKelas",
                table: "topik",
                column: "IdTupleMataPelajaranKelas");

            migrationBuilder.CreateIndex(
                name: "IX_topik_MataPelajaranId",
                table: "topik",
                column: "MataPelajaranId");

            migrationBuilder.CreateIndex(
                name: "IX_topik_Nama",
                table: "topik",
                column: "Nama",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "data_pengajaran");

            migrationBuilder.DropTable(
                name: "nilai_siswa");

            migrationBuilder.DropTable(
                name: "guru");

            migrationBuilder.DropTable(
                name: "siswa");

            migrationBuilder.DropTable(
                name: "topik");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "mata_pelajaran_kelas");

            migrationBuilder.DropTable(
                name: "Kelas");

            migrationBuilder.DropTable(
                name: "mata_pelajaran");
        }
    }
}
