using System;
using System.Collections.Generic;
// using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels 
{
    public class BookView
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public float Rating { get; set; }
        public float Price { get; set; }
        public float PriceModifier { get; set; }
        public string CoverPath { get; set; }
        public string ISBN { get; set; }
        public DateTime Published { get; set; }
    	public string[] MyProperty { get; set; }
    }
}