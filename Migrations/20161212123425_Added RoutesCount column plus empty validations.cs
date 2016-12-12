using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleUrlShortenerSPA.Migrations
{
    public partial class AddedRoutesCountcolumnplusemptyvalidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "ShortedUrls",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrlSuffix",
                table: "ShortedUrls",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoutesCount",
                table: "ShortedUrls",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutesCount",
                table: "ShortedUrls");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "ShortedUrls",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrlSuffix",
                table: "ShortedUrls",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
