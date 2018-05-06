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

        public List<AuthorView> GetAllAuthorsForBook(BookView book)
        {
            return GetAllAuthorsForBook(book.ID);
        }

        public List<AuthorView> GetAllAuthorsForBook(ShortBookView book)
        {
            return GetAllAuthorsForBook(book.BookID);
        }

        public List<AuthorView> GetAllAuthorsForBook(int bookID)
        {
            throw new NotImplementedException();
        }
        public List<AuthorView> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public void AddAuthor(AuthorView Author)
        {
            throw new NotImplementedException();
        }

        public void RemoveAuthor(AuthorView Author)
        {
            RemoveAuthorByID(Author.ID);
        }

        public void RemoveAuthorByID(int id)
        {
            throw new NotImplementedException();
        }

        public void EditAuthor(AuthorView Author)
        {
            throw new NotImplementedException();
        }
    }
}