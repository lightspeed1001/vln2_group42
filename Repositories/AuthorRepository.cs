using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class AuthorRepository
    {
        private DataContext _db;

        public AuthorRepository()
        {
            _db = new DataContext();
        }

        public IEnumerable<AuthorView> GetAllAuthorsForBook(BookView book)
        {
            return GetAllAuthorsForBook(book.ID);
        }

        public IEnumerable<AuthorView> GetAllAuthorsForBook(ShortBookView book)
        {
            return GetAllAuthorsForBook(book.BookID);
        }

        public IEnumerable<AuthorView> GetAllAuthorsForBook(int bookID)
        {
            var authors = (from a in _db.Authors
                           join ba in _db.BookAuthors on a.ID equals ba.AuthorID
                           where ba.BookID == bookID
                           select GetAuthorViewForEntity(a));
            
            return authors;
        }

        public AuthorView GetAuthorByID(int? id)
        {
            var author = (from a in _db.Authors where a.ID == id select a).Single();
            
            return GetAuthorViewForEntity(author);
        }

        public IEnumerable<AuthorView> GetAllAuthors()
        {
            var authors = (from a in _db.Authors select GetAuthorViewForEntity(a));

            return authors;
        }

        public void AddAuthor(AuthorView Author)
        {
            Author a = GetAuthorEntityForView(Author);

            _db.Add(a);
            _db.SaveChanges();
        }

        public void RemoveAuthor(AuthorView Author)
        {
            RemoveAuthorByID(Author.ID);
        }

        public void RemoveAuthorByID(int id)
        {
            Author author = (from a in _db.Authors where a.ID == id select a).Single();
            if(author != null)
            {
                _db.Remove(author);
                _db.SaveChanges();
            }
        }

        public void EditAuthor(AuthorView author)
        {
            var col = _db.Authors.Single(x => x.ID == author.ID);
            if(col != null)
            {
                col.Birthday = author.Birthday;
                col.Description = author.Description;
                col.ImagePath = author.ImagePath;
                col.Name = author.Name;
                _db.SaveChanges();
            }
        }

        public Author GetAuthorEntityForView(AuthorView a)
        {
            if(a == null) return null;
            return new Author
                        {
                            Birthday = a.Birthday,
                            Description = a.Description,
                            ID = a.ID,
                            ImagePath = a.ImagePath,
                            Name = a.Name
                        };
        }

        public AuthorView GetAuthorViewForEntity(Author a)
        {
            if(a == null) return null;
            return new AuthorView
                        {
                            Birthday = a.Birthday,
                            Description = a.Description,
                            ID = a.ID,
                            ImagePath = a.ImagePath,
                            Name = a.Name
                        };
        }
    }
}