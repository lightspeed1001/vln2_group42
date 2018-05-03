using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vln2_group42.Models;

namespace vln2_group42.Controllers
{
    public class BookListController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult TopX(int number)
        {
            return View();
        } 

        public void OrderByAuthor()
        {
            
        }

        public void OrderByTitle()
        {

        }

        public void OrderByYear()
        {

        }

        public void OrderByRating()
        {

        }
    }
}