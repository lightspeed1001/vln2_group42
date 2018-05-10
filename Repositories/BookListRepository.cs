using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookListRepository
    {
        private DataContext _db;

        public BookListRepository()
        {
            _db = new DataContext();
        }

        public IEnumerable<BookListView> GetAllBookListsForUser(UserView user)
        {
            return GetAllBookListsForUser(user.ID);
        }

        public IEnumerable<BookListView> GetAllBookListsForUser(int userID)
        {
            var booklists = (from bl in _db.Lists where bl.CustomerID == userID 
                             select GetViewForEntity(bl));
            return booklists;
        }
        public IEnumerable<BookListView> GetAllBookLists()
        {
            var booklists = (from bl in _db.Lists select GetViewForEntity(bl));
            return booklists;
        }

        public void AddBookList(BookListView bookList)
        {
            CustomerList customerList = GetEntityForView(bookList);
            _db.Add(bookList);
            _db.SaveChanges();
        }

        public void RemoveBookList(BookListView bookList)
        {
            RemoveBookList(bookList.ID);
        }

        public void RemoveBookList(int id)
        {
            var list = _db.Lists.Single(x => x.ID == id);
            _db.Remove(list);
            _db.SaveChanges();
        }

        public void EditBookList(BookListView bookList)
        {
            CustomerList list = _db.Lists.Single(x => x.ID == bookList.ID);
            list.Description = bookList.Description;
            list.Title = bookList.Title;
            
        }

        public IEnumerable<ShortBookView> GetBooksForList(int listID)
        {
            BookRepository bookRepo = new BookRepository(); // Not ideal, but saves a lot of typing
            
            var books = (from b in _db.Books
                         join bl in _db.BooksInLists on b.ID equals bl.BookID
                         where bl.ListID == listID
                         select bookRepo.GetShortViewForEntity(b));
            
            return books;
        }

        public BookListView GetViewForEntity(CustomerList list)
        {
            if(list == null) return null;
            
            BookListView bookListView = new BookListView
                                        {
                                            CustomerID = list.CustomerID,
                                            Description = list.Description,
                                            ID = list.ID,
                                            Title = list.Title,
                                            Books = GetBooksForList(list.ID)                                  
                                        };
            return bookListView;
        }

        public CustomerList GetEntityForView(BookListView bookListView)
        {
            if(bookListView == null) return null;
            CustomerList booklistEntity = new CustomerList
                                        {
                                            CustomerID = bookListView.CustomerID,
                                            Description = bookListView.Description,
                                            ID = bookListView.ID,
                                            Title = bookListView.Title                                            
                                        };
            return booklistEntity;
        }
    }
}