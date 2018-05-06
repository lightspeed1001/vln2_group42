using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vln2_group42.Migrations
{
    public partial class newPasswordRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Customers",
                newName: "HashedPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Customers",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                nullable: true);
        }
    }
}
