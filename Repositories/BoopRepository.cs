using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
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

        public List<BookView> GetDetailedBookView()
        {

            return null;
        }

        public List<ShortBookView> GetAllBooksShortView()
        {
            var books = (from b  in _db.Books 
                         //join ba in _db.BookAuthors on b.ID equals ba.BookID
                         //join a  in _db.Authors on ba.AuthorID equals a.ID
                         select new ShortBookView
                                    {
                                        BookID              = b.ID,
                                        AuthorIDs           = (from ba in _db.BookAuthors where ba.BookID == b.ID select ba.AuthorID).DefaultIfEmpty(0).ToList(),
                                        AuthorName          = string.Join(" & ", (from ba in _db.BookAuthors 
                                                                join a in _db.Authors on ba.AuthorID equals a.ID 
                                                                where ba.BookID == b.ID select a.Name).DefaultIfEmpty("Unknown")),
                                                                //.Aggregate((current, next) => current + " & " + next),
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