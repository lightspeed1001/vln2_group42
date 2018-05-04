using System;
using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Data.EntityModels
{
    public class Book
    {
        public int ID {get; set;}
        public string Title {get; set;}
        public float Price {get; set;}
        public float PriceModifier {get; set;}
        public string CoverPath {get; set;}
        public string ISBN {get; set;}
        public DateTime PublishDate {get; set;}
        public virtual ICollection<Author> Authors {get; set;}
        public virtual ICollection<Genre> Genres {get; set;}
    }
}