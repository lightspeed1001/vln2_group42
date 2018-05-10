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

        public void AddBook(NewBookView book)
        {
            Book bookEntity = new Book
            {
                CoverPath = book.CoverPath,
                InventoryCount = book.InventoryCount,
                ISBN = book.ISBN,
                Price = book.Price,
                PriceModifier = book.PriceModifier,
                PublishDate = book.PublishDate,
                Title = book.Title
            };
            //TODO: Handle genres and authors
            _db.Add(bookEntity);
            _db.SaveChanges();
        }

        public void RemoveBook(int bookID)
        {
            Book bookEntity = _db.Books.Single(x => x.ID == bookID);
            if(bookEntity != null) 
            {
                _db.Remove(bookEntity);
                _db.SaveChanges();
            }
        }

        //Not really used right now
        public void EditBook(BookView book)
        {
            var col = (from b in _db.Books where b.ID==book.ID select b);
            if(col.Count() == 1)
            {
                Book eBook = col.Single();
                eBook.CoverPath = book.CoverPath;
                eBook.InventoryCount = book.InventoryCount;
                eBook.ISBN = book.ISBN;
                eBook.Price = book.Price;
                eBook.PriceModifier = book.PriceModifier;
                eBook.PublishDate = book.Published;
                eBook.Title = book.Title;

                //TODO: Check for new authors & genres
                var authors = (from a in _db.BookAuthors where a.BookID == book.ID select a);
                
                _db.SaveChanges();
            }
        }

        public BookView GetBookByID(int id)
        {
            return GetBookViewForEntity(_db.Books.Single(x => x.ID == id));
        }

        public ShortBookView GetShortBookViewByID(int id)
        {
            return GetShortViewForEntity(_db.Books.Single(x => x.ID == id));
        }

        //Intended for when you click on a book.
        public List<BookView> GetAllDetailedBookView()
        {
            var books = (from b in _db.Books select 
                         GetBookViewForEntity(b)).ToList();
            return books;
        }

        //Intended for quick summaries of books (lists, front page, etc)
        public List<ShortBookView> GetAllBooksShortView()
        {
            var books = (from b  in _db.Books 
                         //join ba in _db.BookAuthors on b.ID equals ba.BookID
                         //join a  in _db.Authors on ba.AuthorID equals a.ID
                         select GetShortViewForEntity(b)).ToList();

            return books;
        }

        public BookView GetBookViewForEntity(Book b)
        {
            if(b == null) return null;
            BookView book =
                new BookView
                {
                    ID              = b.ID,
                    Authors         = (from ba in _db.BookAuthors 
                                        join a in _db.Authors on ba.AuthorID equals a.ID 
                                        where ba.BookID == b.ID 
                                        select new AuthorView
                                        {
                                            ID = a.ID,
                                            Birthday = a.Birthday,
                                            Description = a.Description,
                                            ImagePath = a.ImagePath,
                                            Name = a.Name
                                        }).DefaultIfEmpty(new AuthorView{Name = "Unknown Author" }).ToList(),
                    CoverPath       = b.CoverPath,
                    Price           = b.Price,
                    PriceModifier   = b.PriceModifier,
                    Title           = b.Title,
                    Rating          = (from br in _db.Reviews where br.BookID == b.ID select br.Rating).DefaultIfEmpty(0f).Average(),
                    ISBN            = b.ISBN,
                    Published       = b.PublishDate,
                    Genres          = (from bg in _db.BookGenres
                                        join g in _db.Genres on bg.GenreID equals g.ID
                                        where bg.BookID == b.ID
                                        select new GenreView
                                        {
                                            ID = g.ID,
                                            Name = g.Name
                                        }).DefaultIfEmpty(new GenreView{ Name = "Unknown Genre" }).ToList()
                };
            return book;
        }

        public ShortBookView GetShortViewForEntity(Book b)
        {
            if(b == null) return null;
            ShortBookView book = 
                new ShortBookView
                {
                    BookID              = b.ID,
                    Authors             = (from ba in _db.BookAuthors 
                                            join a in _db.Authors on ba.AuthorID equals a.ID 
                                            where ba.BookID == b.ID select new AuthorView
                                            {
                                                Birthday = a.Birthday,
                                                Description = a.Description,
                                                ID = a.ID,
                                                ImagePath = a.ImagePath,
                                                Name = a.Name
                                            }).DefaultIfEmpty(new AuthorView{Name = "Unknown Author" }).ToList(),
                                            /*string.Join(" & ", (from ba in _db.BookAuthors 
                                            join a in _db.Authors on ba.AuthorID equals a.ID 
                                            where ba.BookID == b.ID select a.Name).DefaultIfEmpty("Unknown")),*/
                    BookCoverPath       = b.CoverPath,
                    BookPrice           = b.Price,
                    BookPriceModifier   = b.PriceModifier,
                    BookTitle           = b.Title,
                    BookRating          = (from br in _db.Reviews where br.BookID == b.ID select br.Rating).DefaultIfEmpty(0f).Average(),
                    Genres              = (from bg in _db.BookGenres
                                            join g in _db.Genres on bg.GenreID equals g.ID
                                            where bg.BookID == b.ID
                                            select new GenreView
                                            {
                                                ID = g.ID,
                                                Name = g.Name
                                            }).DefaultIfEmpty(new GenreView{ Name = "Unknown Genre" }).ToList()
                };
            return book;
        }
    }
}