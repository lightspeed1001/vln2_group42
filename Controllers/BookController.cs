using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        public IActionResult ViewBook(int bookID)
        {
            
            /*var book = (from a in Database.books
                        where a.Id == id
                        select new BookView{
                            Title = a.Title,
                            ...
                            }).ToList();
                        */
            return View();
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