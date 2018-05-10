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
            var derp = (from gb in _db.BookGenres
                        join g in _db.Genres on gb.GenreID equals g.ID
                        where gb.BookID == bookID
                        select GetViewForEntity(g)).ToList();

            return derp;
        }
        public List<GenreView> GetAllGenres()
        {
            var derp = (from g in _db.Genres
                        select GetViewForEntity(g)).ToList();

            return derp;
        }

        public void AddGenre(GenreView genre)
        {
            Genre genreEntity = GetEntityForView(genre);
            _db.Add(genreEntity);
            _db.SaveChanges();
        }

        public void RemoveGenre(GenreView genre)
        {
            RemoveGenreByID(genre.ID);
        }

        public void RemoveGenreByID(int id)
        {
            var genre = (from g in _db.Genres 
                        where g.ID == id select g).Single();
            if(genre != null)
            {
                var genreConnections = (from gb in _db.BookGenres
                                        where gb.GenreID == id select gb);
                _db.Remove(genre);
                _db.Remove(genreConnections);
                _db.SaveChanges();
            }
        }

        public void EditGenre(GenreView genre)
        {
            var genreEntity = (from g in _db.Genres
                                where g.ID == genre.ID select g).Single();
            if(genreEntity != null)
            {
                genreEntity.Name = genre.Name;
                _db.SaveChanges();
            }
        }

        public GenreView GetViewForEntity(Genre g)
        {
            if(g == null) return null;
            GenreView gv = new GenreView
            {
                ID = g.ID,
                Name = g.Name
            };

            return gv;
        }

        public Genre GetEntityForView(GenreView g)
        {
            if(g == null) return null;
            Genre ge = new Genre
            {
                ID = g.ID,
                Name = g.Name
            };

            return ge;
        }
    }
}