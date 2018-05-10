using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels 
{
    public class ShortBookView
    {
        public int BookID { get; set; }
        public List<AuthorView> Authors { get; set; }
        public List<GenreView> Genres {get; set;}
        public string BookTitle { get; set; }
        public float BookRating { get; set; }
        public float BookPrice { get; set; }
        public float BookPriceModifier { get; set; }
        public string BookCoverPath { get; set; }
    }
}