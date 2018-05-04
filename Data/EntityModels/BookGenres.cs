using System;

namespace BookCave.Data.EntityModels
{
    public class BookGenre
    {
        public int BookID {get; set;}
        public Book Book {get; set;}

        public int GenreID {get; set;}
        public Genre Genre {get; set;}
    }
}