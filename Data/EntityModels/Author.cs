using System;

namespace BookCave.Data.EntityModels
{
    public class Author
    {  
        public int ID {get; set;}
        public string Name {get; set;}
        public DateTime Birthday {get; set;}
        public string Description {get; set;}
        public string ImagePath {get; set;}
    }
}