using System;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class BookListView
    {
        public int ID {get; set;}
        public int CustomerID {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
    }
}