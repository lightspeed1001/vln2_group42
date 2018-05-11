using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Repositories;
using BookCave.Models.ViewModels;
using BookCave.Models.Enums;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            GenreRepository genreRepo = new GenreRepository();
            ViewBag.Categories = genreRepo.GetAllGenres();

            //TestData();
            return View();
        }
        public IActionResult Description()
        {
            return View();
        }

        public IActionResult Details(int? id) 
        {
            
            return View();
        }

        public static void TestData()
        {
            BookRepository bookRepo = new BookRepository();
            var books = bookRepo.GetAllBooksShortView();
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