using Microsoft.EntityFrameworkCore.Migrations;

namespace MultipleDbIssues.Data.Migrations.Sites
{
    public partial class RenameSiteDomainToDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SiteDomain",
                table: "Sites",
                newName: "Domain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Domain",
                table: "Sites",
                newName: "SiteDomain");
        }
    }
}
