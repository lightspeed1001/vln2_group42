using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class GenreRepository
    {
        private DataContext _db;

        public GenreRepository()
        {
            _db = new DataContext();
        }

        public List<GenreView> GetAllGenresForBook(BookView book)
        {
            return GetAllGenresForBook(book.ID);
        }

        public List<GenreView> GetAllGenresForBook(ShortBookView book)
        {
            return GetAllGenresForBook(book.BookID);
        }

        public List<GenreView> GetAllGenresForBook(int bookID)
        {
            throw new NotImplementedException();
        }
        public List<GenreView> GetAllGenres()
        {
            var genres =    (from g in _db.Genres 
                            select new GenreView
                            {
                                ID = g.ID,
                                Name = g.Name
                            }
                            ).ToList();
            return genres;

        }

        public void AddGenre(GenreView genre)
        {
            throw new NotImplementedException();
        }

        public void RemoveGenre(GenreView genre)
        {
            RemoveGenreByID(genre.ID);
        }

        public void RemoveGenreByID(int id)
        {
            throw new NotImplementedException();
        }

        public void EditGenre(GenreView genre)
        {
            throw new NotImplementedException();
        }
    }
}