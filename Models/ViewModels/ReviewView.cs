using System;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class ReviewView
    {
        public int ID {get; set;}
        public int CustomerID {get; set;}
        public int BookID {get; set;}
        public string Text {get; set;}
        public float Rating {get; set;}
    }
}