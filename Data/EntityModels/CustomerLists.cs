using System;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Data.EntityModels
{
    public class CustomerList
    {
        public int ID {get; set;}
        
        [Required]
        public int CustomerID {get; set;}
        
        [Required]
        //public Customer Owner {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        //public System.Collections.Generic.List<BooksInList> BooksInList {get; set;}
    }
}