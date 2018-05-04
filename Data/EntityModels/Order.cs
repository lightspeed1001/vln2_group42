using System;
using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public int ID {get; set;}
        public Customer Customer {get; set;}
        public Models.Enums.OrderStatus Status {get; set;}
        public DateTime DateCompleted {get; set;}
        public float ShippingCost {get; set;}
        public float TotalCost {get; set;}

        public List<BookInOrder> BooksInOrder {get; set;}
    }
}