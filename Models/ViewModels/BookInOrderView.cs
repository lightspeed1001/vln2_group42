using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookInOrderView
    {
        public int OrderID {get; set;}
        //public Order Order {get; set;}
        public int BookID {get; set;}
        public ShortBookView Book {get; set;}
        //public Book Book {get; set;}
        public float Price {get; set;}
        public int NumberOfCopies {get; set;}
    }
}