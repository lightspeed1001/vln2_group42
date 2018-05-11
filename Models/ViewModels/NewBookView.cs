using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.Enums;

namespace BookCave.Models.ViewModels
{
    public class NewBookView
    {
        public NewBookView()
        {
            CoverPath = Defaults.DefaultBookImage;
            PublishDate = DateTime.Now;
            InventoryCount = 0;
        }

        [Required]
        public string Title {get; set;}

        [Required, Range(0, Int32.MaxValue)]
        public float Price {get; set;}
        public string CoverPath {get; set;}

        [Required]
        public string ISBN {get; set;}
        public DateTime PublishDate {get; set;}
        public int InventoryCount {get; set;}
        public IEnumerable<int> AuthorIDs {get; set;}
        public IEnumerable<int> GenreIDs {get; set;}
    }
}