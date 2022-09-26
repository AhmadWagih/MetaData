using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaData.Migrations
{
    public partial class afterController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeylessEntity");

            migrationBuilder.AddColumn<string>(
                name: "Layers",
                table: "VectorsData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coverage",
                table: "MainInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverageEntity",
                table: "MainInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MainInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layers",
                table: "VectorsData");

            migrationBuilder.DropColumn(
                name: "Coverage",
                table: "MainInfos");

            migrationBuilder.DropColumn(
                name: "CoverageEntity",
                table: "MainInfos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MainInfos");

            migrationBuilder.CreateTable(
                name: "KeylessEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainInfoId = table.Column<int>(type: "int", nullable: true),
                    VectorDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeylessEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeylessEntity_MainInfos_MainInfoId",
                        column: x => x.MainInfoId,
                        principalTable: "MainInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeylessEntity_VectorsData_VectorDataId",
                        column: x => x.VectorDataId,
                        principalTable: "VectorsData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeylessEntity_MainInfoId",
                table: "KeylessEntity",
                column: "MainInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_KeylessEntity_VectorDataId",
                table: "KeylessEntity",
                column: "VectorDataId");
        }
    }
}
