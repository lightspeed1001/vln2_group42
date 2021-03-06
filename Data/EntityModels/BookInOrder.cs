using System;

namespace BookCave.Data.EntityModels
{
    public class BookInOrder
    {
        public BookInOrder()
        {
            NumberOfCopies = 1;
            Price = 1f;
        }
        public int OrderID {get; set;}
        //public Order Order {get; set;}
        public int BookID {get; set;}
        //public Book Book {get; set;}
        public float Price {get; set;}
        public int NumberOfCopies {get; set;}
    }
}