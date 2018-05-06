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
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
    }
}
