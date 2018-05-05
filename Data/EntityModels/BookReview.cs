using System;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Data.EntityModels
{
    public class BookReview
    {
        public int ID {get; set;}

        [Required]
        public int CustomerID {get; set;}
        //public Customer Customer {get; set;}
        
        [Required]
        public int BookID {get; set;}
        //public Book Book {get; set;}
        public string Text {get; set;}

        [Required]
        public float Rating {get; set;}
    }
}