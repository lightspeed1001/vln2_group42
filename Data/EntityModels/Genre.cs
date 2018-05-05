using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Data.EntityModels
{
    public class Genre
    {
        public int ID {get; set;}
        
        [Required]
        public string Name {get; set;}
        //public virtual List<BookGenre> BookGenres {get; set;}
    }
}