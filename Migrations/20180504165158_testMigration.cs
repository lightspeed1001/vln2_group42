using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vln2_group42.Migrations
{
    public partial class testMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorID",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BookID",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Books_BookID",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Genres_GenreID",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInLists_Books_BookID",
                table: "BooksInLists");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInLists_Lists_ListID",
                table: "BooksInLists");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInOrders_Books_BookID",
                table: "BooksInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInOrders_Orders_OrderID",
                table: "BooksInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Customers_OwnerID",
                table: "Lists");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CustomerID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Lists_OwnerID",
                table: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_BooksInOrders_OrderID",
                table: "BooksInOrders");

            migrationBuilder.DropIndex(
                name: "IX_BooksInLists_ListID",
                table: "BooksInLists");

            migrationBuilder.DropIndex(
                name: "IX_BookGenres_GenreID",
                table: "BookGenres");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_AuthorID",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Lists");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Lists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Lists");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Lists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookID",
                table: "Reviews",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerID",
                table: "Reviews",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_OwnerID",
                table: "Lists",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_BooksInOrders_OrderID",
                table: "BooksInOrders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_BooksInLists_ListID",
                table: "BooksInLists",
                column: "ListID");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreID",
                table: "BookGenres",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorID",
                table: "BookAuthors",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorID",
                table: "BookAuthors",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BookID",
                table: "BookAuthors",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Books_BookID",
                table: "BookGenres",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Genres_GenreID",
                table: "BookGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInLists_Books_BookID",
                table: "BooksInLists",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInLists_Lists_ListID",
                table: "BooksInLists",
                column: "ListID",
                principalTable: "Lists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInOrders_Books_BookID",
                table: "BooksInOrders",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInOrders_Orders_OrderID",
                table: "BooksInOrders",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Customers_OwnerID",
                table: "Lists",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookID",
                table: "Reviews",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerID",
                table: "Reviews",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
