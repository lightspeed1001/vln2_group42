using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class AuthorView
    {  
        public int ID {get; set;}
        public string Name {get; set;}
        public DateTime Birthday {get; set;}
        public string Description {get; set;}
        public string ImagePath {get; set;}
    }
}