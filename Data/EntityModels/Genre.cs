using System;
using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Genre
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public virtual List<BookGenre> BookGenres {get; set;}
    }
}