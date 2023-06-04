using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RickAndMorty.Infrastracture.Migrations
{
    public partial class Seestablecenuevamenterelacionmuchosamuchosentrecharacteryepisode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Species",
                table: "Characters",
                newName: "Specie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specie",
                table: "Characters",
                newName: "Species");
        }
    }
}
