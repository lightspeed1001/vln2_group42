using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepository
    {
        private DataContext _db;
        
        public BookRepository()
        {
            _db = new DataContext();
        }

        //Not really used right now
        public void EditBook(BookView book)
        {
            var col = (from b in _db.Books where b.ID==book.ID select b);
            if(col.Count() == 1)
            {
                Book eBook = col.First();
                eBook.CoverPath = book.CoverPath;
                eBook.InventoryCount = book.InventoryCount;
                eBook.ISBN = book.ISBN;
                eBook.Price = book.Price;
                eBook.PriceModifier = book.PriceModifier;
                eBook.PublishDate = book.Published;
                eBook.Title = book.Title;
                var authors = (from a in _db.BookAuthors where a.BookID == book.ID select a);
                _db.SaveChanges();
            }
        }

        //Intended for when you click on a book.
        public List<BookView> GetDetailedBookView()
        {
            var books = (from b in _db.Books select 
                         new BookView
                         {
                             ID              = b.ID,
                             Author          = (from ba in _db.BookAuthors 
                                                join a in _db.Authors on ba.AuthorID equals a.ID 
                                                where ba.BookID == b.ID 
                                                select new AuthorView
                                                {
                                                    ID = a.ID,
                                                    Birthday = a.Birthday,
                                                    Description = a.Description,
                                                    ImagePath = a.ImagePath,
                                                    Name = a.Name
                                                }).DefaultIfEmpty(new AuthorView()).First(),
                             CoverPath       = b.CoverPath,
                             Price           = b.Price,
                             PriceModifier   = b.PriceModifier,
                             Title           = b.Title,
                             Rating          = (from br in _db.Reviews where br.BookID == b.ID select br.Rating).DefaultIfEmpty(0f).Average(),
                             ISBN            = b.ISBN,
                             Published       = b.PublishDate,
                         }).ToList();
            return books;
        }

        //Intended for quick summaries of books (lists, front page, etc)
        public List<ShortBookView> GetAllBooksShortView()
        {
            var books = (from b  in _db.Books 
                         //join ba in _db.BookAuthors on b.ID equals ba.BookID
                         //join a  in _db.Authors on ba.AuthorID equals a.ID
                         select new ShortBookView
                                    {
                                        BookID              = b.ID,
                                        AuthorID            = (from ba in _db.BookAuthors where ba.BookID == b.ID select ba.AuthorID).DefaultIfEmpty(0).First(),
                                        AuthorName          = (from ba in _db.BookAuthors 
                                                                join a in _db.Authors on ba.AuthorID equals a.ID 
                                                                where ba.BookID == b.ID select a.Name).DefaultIfEmpty("Unknown").First(),
                                                                /*string.Join(" & ", (from ba in _db.BookAuthors 
                                                                join a in _db.Authors on ba.AuthorID equals a.ID 
                                                                where ba.BookID == b.ID select a.Name).DefaultIfEmpty("Unknown")),*/
                                        BookCoverPath       = b.CoverPath,
                                        BookPrice           = b.Price,
                                        BookPriceModifier   = b.PriceModifier,
                                        BookTitle           = b.Title,
                                        BookRating          = (from br in _db.Reviews where br.BookID == b.ID select br.Rating).DefaultIfEmpty(0f).Average()
                                    }).ToList();

            return books;
        }
    }
}