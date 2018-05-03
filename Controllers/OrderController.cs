using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;

namespace BookCave.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult ViewOrder()
        {
            return View();
        }

        public IActionResult EditOrder()
        {
            return View();
        }

        public IActionResult VerifyOrder()
        {
            return View();
        }

        public IActionResult SubmitOrder()
        {
            return View();
        }

        public IActionResult CancelOrder()
        {
            return View();
        }

        public bool MoveBookToList()
        {
            return false;
        }

        public bool CreateListFromCart()
        {
            return false;
        }
        
        public bool AddToCart()
        {
            return false;
        }
    }
}