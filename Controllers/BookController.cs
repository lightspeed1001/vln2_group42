using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vln2_group42.Models;

namespace vln2_group42.Controllers
{
    public class BookController : Controller
    {
        public IActionResult ViewBook()
        {
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