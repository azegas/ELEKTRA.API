using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELEKTRA.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Watts = table.Column<double>(type: "float", nullable: false),
                    Kilowatts = table.Column<double>(type: "float", nullable: false),
                    ElectricityCost = table.Column<double>(type: "float", nullable: false),
                    HourlyCost = table.Column<double>(type: "float", nullable: false),
                    DailyCost = table.Column<double>(type: "float", nullable: false),
                    WeeklyCost = table.Column<double>(type: "float", nullable: false),
                    MonthlyCost = table.Column<double>(type: "float", nullable: false),
                    YearlyCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");
        }
    }
}
