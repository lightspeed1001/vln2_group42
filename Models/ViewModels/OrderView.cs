using System;
using System.Collections.Generic;
using BookCave.Models.Enums;
// using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderView
    {
        public int ID { get; set; }
        public IEnumerable<BookInOrderView> Books { get; set; }
        
        public UserView Owner { get; set; }
        public int OwnerID {get; set;}
        public OrderStatus Status { get; set; }
        public float ShippingCost {get; set;}
        public DateTime DateCompleted {get; set;}
        public float TotalPrice {get; set;}
    }
}