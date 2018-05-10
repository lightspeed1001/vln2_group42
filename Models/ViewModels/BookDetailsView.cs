using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class BookDetailsView
    {
        public string Title {get; set;}
        public IEnumerable<AuthorView> Authors { get; set; }
        public float BookPrice { get; set; }
        public IEnumerable<GenreView> Genres {get; set;}
    }
}