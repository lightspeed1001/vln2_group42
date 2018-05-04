using System;

namespace BookCave.Data.EntityModels
{
    public class CustomerList
    {
        public int ID {get; set;}
        public Customer Owner {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public System.Collections.Generic.List<BooksInList> BooksInList {get; set;}
    }
}