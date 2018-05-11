using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.ViewModels;
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
        public IActionResult Details(int? id)
        {
            BookService BookSer = new BookService();
            var book = BookSer.GetAllBooksByID(id).First();
            ViewBag.Book = book;
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