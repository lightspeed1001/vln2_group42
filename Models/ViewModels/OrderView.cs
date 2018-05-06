using System;
using System.Collections.Generic;
using BookCave.Models.Enums;
// using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderView
    {
        public int ID { get; set; }
        public List<BookView> Books { get; set; }
        public UserView Owner { get; set; }
        public OrderStatus Status { get; set; }

        public int GetTotalPrice()
        {
            return 0;
        }
    }
}