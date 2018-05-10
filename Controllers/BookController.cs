using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
<<<<<<< HEAD
using BookCave.Services;
=======
using BookCave.Models.ViewModels;
>>>>>>> 1074473bbd2b88e955e14b267bfe97c064eb688d
using BookCave.Repositories;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        public IActionResult ViewBook(int bookID)
        {
            BookView book = new BookRepository().GetBookByID(bookID);
            return View(book);
        }
        
        public IActionResult EditBook()
        {
            
            return View();
        }
        public IActionResult CreateBook()
        {
            return View();
        }
        public IActionResult ReviewBook()
        {
            return View();
        }
        public bool AddToCart()
        {
            
            return true;
        }
    }
}