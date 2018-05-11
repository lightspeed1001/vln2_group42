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
                PublishDate = book.PublishDate,
                Title = book.Title
            };
            //TODO: Handle genres and authors
            
            _db.Add(bookEntity);
            _db.SaveChanges();
        }

        public void AddAuthorToBook(AuthorView author, BookView book)
        {
            AddAuthorToBook(author.ID, book.ID);
        }

        public void AddAuthorToBook(int authorID, int bookID)
        {
            _db.Add(new BookAuthor{BookID = bookID, AuthorID = authorID});
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
                eBook.PublishDate = book.Published;
                eBook.Title = book.Title;

                //TODO: Check for new authors & genres
                var authors = (from a in _db.BookAuthors where a.BookID == book.ID select a);
                
                _db.SaveChanges();
            }
        }

        public IEnumerable<BookView> GetBooksInOrder(int orderID)
        {
            var books = (from bo in _db.BooksInOrders
                         join b in _db.Books on bo.BookID equals b.ID
                         where bo.OrderID == orderID
                         select GetBookViewForEntity(b));
            return books;
        }

        public IEnumerable<ShortBookView> GetShortBooksInOrder(int orderID)
        {
            var books = (from bo in _db.BooksInOrders
                         join b in _db.Books on bo.BookID equals b.ID
                         where bo.OrderID == orderID
                         select GetShortViewForEntity(b));
            return books;
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
        public IEnumerable<BookView> GetAllDetailedBookView()
        {
            var books = (from b in _db.Books select 
                         GetBookViewForEntity(b));
            return books;
        }

        //Intended for quick summaries of books (lists, front page, etc)
        public IEnumerable<ShortBookView> GetAllBooksShortView()
        {
            var books = (from b  in _db.Books 
                         //join ba in _db.BookAuthors on b.ID equals ba.BookID
                         //join a  in _db.Authors on ba.AuthorID equals a.ID
                         select GetShortViewForEntity(b));

            return books;
        }
        public IEnumerable<BookDetailsView> GetAllBookDetailsView()
        {
            var books = (from b in _db.Books
                        select GetBookDetailsView(b));
            return books;
        }
        public BookView GetBookViewForEntity(Book b)
        {
            if(b == null) return null;
            var authors = (from ba in _db.BookAuthors 
                            join a in _db.Authors on ba.AuthorID equals a.ID 
                            where ba.BookID == b.ID 
                            select new AuthorView
                            {
                                ID = a.ID,
                                Birthday = a.Birthday,
                                Description = a.Description,
                                ImagePath = a.ImagePath,
                                Name = a.Name
                            }).DefaultIfEmpty(new AuthorView{Name = "Unknown Author" });
            var ratings = (from br in _db.Reviews where br.BookID == b.ID select br.Rating).DefaultIfEmpty(0f).Average();
            var genres =  (from bg in _db.BookGenres
                            join g in _db.Genres on bg.GenreID equals g.ID
                            where bg.BookID == b.ID
                            select new GenreView
                            {
                                ID = g.ID,
                                Name = g.Name
                            }).DefaultIfEmpty(new GenreView{ Name = "Unknown Genre" });
            BookView book =
                new BookView
                {
                    ID              = b.ID,
                    Authors         = authors,
                    CoverPath       = b.CoverPath,
                    Price           = b.Price,
                    Title           = b.Title,
                    Rating          = ratings,
                    ISBN            = b.ISBN,
                    Published       = b.PublishDate,
                    Genres          = genres
                };
            return book;
        }

        public ShortBookView GetShortViewForEntity(Book b)
        {
            if(b == null) return null;
            var authors = (from ba in _db.BookAuthors 
                            join a in _db.Authors on ba.AuthorID equals a.ID 
                            where ba.BookID == b.ID select new AuthorView
                            {
                                Birthday = a.Birthday,
                                Description = a.Description,
                                ID = a.ID,
                                ImagePath = a.ImagePath,
                                Name = a.Name
                            }).DefaultIfEmpty(new AuthorView{Name = "Unknown Author" });
                  
            var ratings = (from br in _db.Reviews where br.BookID == b.ID select br.Rating).DefaultIfEmpty(0f);
            var genres = (from bg in _db.BookGenres
                                            join g in _db.Genres on bg.GenreID equals g.ID
                                            where bg.BookID == b.ID
                                            select new GenreView
                                            {
                                                ID = g.ID,
                                                Name = g.Name
                                            }).DefaultIfEmpty(new GenreView{ Name = "Unknown Genre" });
            ShortBookView book = 
                new ShortBookView
                {
                    BookID              = b.ID,
                    Authors             = authors,
                    BookCoverPath       = b.CoverPath,
                    BookPrice           = b.Price,
                    BookTitle           = b.Title,
                    BookRating          = ratings,
                    Genres              = genres
                };
            return book;
        }
        public BookDetailsView GetBookDetailsView(Book b)
        {
            if (b == null) return null;
            var authors = (from ba in _db.BookAuthors 
                        join a in _db.Authors on ba.AuthorID equals a.ID 
                        where ba.BookID == b.ID select new AuthorView
                        {
                            Birthday = a.Birthday,
                            Description = a.Description,
                            ID = a.ID,
                            ImagePath = a.ImagePath,
                            Name = a.Name
                        }).DefaultIfEmpty(new AuthorView{Name = "Unknown Author" });
            var genres = (from bg in _db.BookGenres
                                            join g in _db.Genres on bg.GenreID equals g.ID
                                            where bg.BookID == b.ID
                                            select new GenreView
                                            {
                                                ID = g.ID,
                                                Name = g.Name
                                            }).DefaultIfEmpty(new GenreView{ Name = "Unknown Genre" });
            BookDetailsView book = new BookDetailsView
                {
                    ID = b.ID,
                    Title = b.Title,
                    Authors = authors,
                    BookPrice = b.Price,
                    Genres = genres
                };
            return book;
        
        }
    }
}