using Microsoft.EntityFrameworkCore.Migrations;

namespace IOTWebAPI.Migrations
{
    public partial class AddConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    ConfigurationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GatewayID = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.ConfigurationID);
                    table.ForeignKey(
                        name: "FK_Configurations_Gateways_GatewayID",
                        column: x => x.GatewayID,
                        principalTable: "Gateways",
                        principalColumn: "GatewayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_GatewayID",
                table: "Configurations",
                column: "GatewayID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");
        }
    }
}
