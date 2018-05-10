using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService
    {
        private BookRepository _bookRepo;

        public BookService()
        {
            _bookRepo = new BookRepository();
        }

        //Search functions
        public List<ShortBookView> GetAllBooksByAuthor(string authorName)
        {
            authorName = authorName.ToLower();
            var allBooks = GetAllBooksShort();
            var searchResults = (from b in allBooks where b.Authors.Exists(x => x.Name == authorName) select b).ToList();

            return searchResults;
        }

        //Generic fetchers
        public List<ShortBookView> GetAllBooksShort()
        {
            return _bookRepo.GetAllBooksShortView();
        }

        public List<BookView> GetAllBooksDetailed()
        {
            return _bookRepo.GetDetailedBookView();
        }
        public List<BookView> GetAllBooksByID(int? id)
        {
            
            return GetAllBooksByID(1);
        }
    }
}