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
            GenreRepository genreRepo = new GenreRepository();
            ViewBag.Categories = genreRepo.GetAllGenres();

            TestData();
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
                Console.WriteLine(bla);
            }
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