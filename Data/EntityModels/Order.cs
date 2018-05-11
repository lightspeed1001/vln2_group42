using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.Enums;

namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public Order()
        {
            Status = OrderStatus.New;
        }
        public int ID {get; set;}
        
        [Required]
        public int CustomerID {get; set;}
        //public Customer Customer {get; set;}
        public Models.Enums.OrderStatus Status {get; set;}
        public DateTime DateCompleted {get; set;}
        public float ShippingCost {get; set;}
        // public float TotalCost {get; set;} //Derived data

        // public List<BookInOrder> BooksInOrder {get; set;}
    }
}