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
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            AuthorService author = new AuthorService();
            ViewBag.Author = author.GetAuthorByID(id);
            return View();
        }
    }
}