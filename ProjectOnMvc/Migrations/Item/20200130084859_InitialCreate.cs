using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectOnMvc.Migrations.Item
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Cid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cname = table.Column<string>(nullable: true),
                    Subid = table.Column<int>(nullable: false),
                    Subname = table.Column<string>(nullable: true),
                    itemid = table.Column<int>(nullable: false),
                    itemname = table.Column<string>(nullable: true),
                    itemprice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Cid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item");
        }
    }
}
