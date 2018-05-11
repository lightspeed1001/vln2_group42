using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels 
{
    public class BookView
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public IEnumerable<AuthorView> Authors { get; set; }
        public float Rating { get; set;}
        public float Price { get; set; }
        public string CoverPath { get; set; }
        public string ISBN { get; set; }
        public DateTime Published { get; set; }
        public int InventoryCount {get; set;}
        public IEnumerable<GenreView> Genres {get; set;}
    }
}