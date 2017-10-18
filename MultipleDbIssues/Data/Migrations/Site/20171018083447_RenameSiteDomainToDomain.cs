using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MultipleDbIssues.Data.Migrations.Site
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
