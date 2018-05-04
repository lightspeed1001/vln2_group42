using System;

namespace BookCave.Data.EntityModels
{
    public class BookReview
    {
        public int ID {get; set;}
        //public int CustomerID {get; set;}
        public Customer Customer {get; set;}
        //public int BookID {get; set;}
        public Book Book {get; set;}
        public string Text {get; set;}
        public float Rating {get; set;}
    }
}