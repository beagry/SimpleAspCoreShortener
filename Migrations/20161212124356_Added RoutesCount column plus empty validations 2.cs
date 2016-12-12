using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleUrlShortenerSPA.Migrations
{
    public partial class AddedRoutesCountcolumnplusemptyvalidations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoutesCount",
                table: "ShortedUrls",
                newName: "NavigationsCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NavigationsCount",
                table: "ShortedUrls",
                newName: "RoutesCount");
        }
    }
}
