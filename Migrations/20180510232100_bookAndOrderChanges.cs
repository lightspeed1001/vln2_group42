using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vln2_group42.Migrations
{
    public partial class bookAndOrderChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceModifier",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCopies",
                table: "BooksInOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCopies",
                table: "BooksInOrders");

            migrationBuilder.AddColumn<float>(
                name: "PriceModifier",
                table: "Books",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
