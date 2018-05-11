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
        public IEnumerable<ShortBookView> GetAllBooksByAuthor(string authorName)
        {
            /*authorName = authorName.ToLower();
            var allBooks = GetAllBooksShort();
            var searchResults = (from b in allBooks where b.Authors.Exists(x => x.Name == authorName) select b);

            return searchResults;*/
            return null;
        }

        public IEnumerable<ShortBookView> GetAllBooksShortView()
        {
            return _bookRepo.GetAllBooksShortView();
        }
        //Generic fetchers
        public IEnumerable<ShortBookView> GetAllBooksShort()
        {
            return _bookRepo.GetAllBooksShortView();
        }

        public IEnumerable<BookView> GetAllBooksDetailed()
        {
            return _bookRepo.GetAllDetailedBookView();
        }
        public IEnumerable<BookDetailsView> GetAllBooksByID(int? id)
        {
            var allBooks = _bookRepo.GetAllBookDetailsView();
            var results = (from b in allBooks where b.ID == id select b);
            return results;
        }
    }
}