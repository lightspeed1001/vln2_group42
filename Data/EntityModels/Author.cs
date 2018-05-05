using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.Enums;

namespace BookCave.Data.EntityModels
{
    public class Author
    {  
        public Author()
        {
            Birthday = DateTime.Now;
            Description = Defaults.DefaultAuthorDescription;
            ImagePath = Defaults.DefaultAuthorImage;
        }

        public int ID {get; set;}
        
        [Required]
        public string Name {get; set;}
        public DateTime Birthday {get; set;}
        public string Description {get; set;}
        public string ImagePath {get; set;}
        //public virtual List<BookAuthor> BookAuthors {get; set;}
    }
}