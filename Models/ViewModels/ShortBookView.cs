using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels 
{
    public class ShortBookView
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public float BookRating { get; set; }
        public float BookPrice { get; set; }
        public float BookPriceModifier { get; set; }
        public string BookCoverPath { get; set; }
    }
}