using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class BookDetailsView
    {
        public string Title {get; set;}
        public string Author {get; set;}
        public string Publisher {get; set;}
        public string Genre {get; set;}
    }
}