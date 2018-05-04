using System;
using System.Collections.Generic;

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
        public int InventoryCount {get; set;}
        public virtual List<BookAuthor> BookAuthors {get; set;}
        public virtual List<BookGenre> BookGenres {get; set;}
        public virtual List<BookInOrder> BooksInOrder {get; set;}
        public virtual List<BooksInList> BooksInList {get; set;}
        public virtual List<BookReview> Reviews {get; set;}
    }
}