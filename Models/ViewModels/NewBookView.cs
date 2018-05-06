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
            PriceModifier = 1f;
            CoverPath = Defaults.DefaultBookImage;
            PublishDate = DateTime.Now;
            InventoryCount = 0;
        }

        [Required]
        public string Title {get; set;}

        [Required, Range(0, Int32.MaxValue)]
        public float Price {get; set;}

        //Intended as a discount type thing
        public float PriceModifier {get; set;}
        public string CoverPath {get; set;}

        [Required]
        public string ISBN {get; set;}
        public DateTime PublishDate {get; set;}
        public int InventoryCount {get; set;}
    }
}