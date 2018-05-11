using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Services;
using BookCave.Repositories;
using BookCave.Models.ViewModels;
using BookCave.Models.Enums;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Quick test
            /*BookRepository bookRepo = new BookRepository();
            List<BookView> books = bookRepo.GetDetailedBookView();
            books[0].Price = 100;
            books[0].ISBN = "penis";
            bookRepo.EditBook(books[0]);
            var books2 = bookRepo.GetAllBooksShortView();
            
            return View(books2);*/
            GenreService GenreSer = new GenreService();
            ViewBag.Categories = GenreSer.GetAllGenres();

            //TestData();
            return View();
        }
        public IActionResult Description()
        {
            return View();
        }

        public IActionResult Details(int? id) 
        {
            GenreService GenreSer = new GenreService();
            //BookService bookSer = new BookService();
            ViewBag.Categories = GenreSer.GetAllGenres();
            BookRepository bookRepo = new BookRepository();
            //Use shortbookview for when you just need a quick overview of a book
            //For example when listing lots of books.
            var books = bookRepo.GetShortBooksForGenre(id.GetValueOrDefault());
            //var BookDetails = bookSer.GetAllBooksByID(id);
            ViewBag.Books = books;
            return View();
        }

        public static void TestData()
        {
            BookService bookSer = new BookService();
            var books = bookSer.GetAllBooksShortView();
            foreach (var book in books)
            {
                string bla = "Title: " + book.BookTitle + "\n";
                bla       += "Author(s): " + String.Join(" & ", book.Authors.Select(x => x.Name))  + "\n";
                bla       += "Genre(s): " + String.Join(" & ", book.Genres.Select(x => x.Name))  + "\n";
                bla       += "Rating: " + book.BookRating.Average() + "\n";
                bla       += "Price: " + book.BookPrice + "\n";
                //Console.WriteLine(bla);
            }

            OrderRepository orderRepo = new OrderRepository();
            /*NewOrderView newOrder = new NewOrderView
            {
                OwnerID = 2,
                ShippingCost = 10f,
                BookIDs = new int[]{3, 4, 2}
            };

            int orderID = orderRepo.AddOrder(newOrder);
            orderRepo.AddBooksToOrder(newOrder.BookIDs, orderID);*/
            int orderID = 2;
            OrderView testOrder = orderRepo.GetOrderByID(orderID);
            string bla2  = "Order ID: " + testOrder.ID + "\n";
                   bla2 += "Owner ID: " + testOrder.OwnerID + "\n";
                   bla2 += "--Books--" + "\n";
            foreach (var b in testOrder.Books)
            {
                bla2 += "Title: " + b.Book.BookTitle + "; ";
                bla2 += "Count: " + b.NumberOfCopies + "\n";
            }
            //Console.WriteLine(bla2);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UserControlPanel()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }
        public IActionResult Action()
        {
            return View();
        }
        public IActionResult Romance()
        {
            
            return View();
        }
          public IActionResult Comedy()
        {
            
            return View();
        }
          public IActionResult YoungAdult()
        {
            
            return View();
        }
          public IActionResult Philosophy()
        {
            
            return View();
        }
          public IActionResult NonFiction()
        {
            
            return View();
        }
    }
}