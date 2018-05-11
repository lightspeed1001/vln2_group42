using System;
using System.Collections.Generic;
using BookCave.Models.Enums;
// using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class NewOrderView
    {
        public IEnumerable<int> BookIDs { get; set; }
        public int OwnerID {get; set;}
        public float ShippingCost {get; set;}
    }
}