using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels 
{
    public class ShortBookView
    {
        public int BookID { get; set; }
        public IEnumerable<AuthorView> Authors { get; set; }
        public IEnumerable<GenreView> Genres {get; set;}
        public string BookTitle { get; set; }
        public IEnumerable<float> BookRating { get; set; }
        public float BookPrice { get; set; }
        public float BookPriceModifier { get; set; }
        public string BookCoverPath { get; set; }
    }
}