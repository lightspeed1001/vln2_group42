using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class GenreService
    {
        private GenreRepository _genreRepo;

        public GenreService()
        {
            _genreRepo = new GenreRepository();
        }

        public IEnumerable<GenreView> GetAllGenres() 
        {
            var genres = _genreRepo.GetAllGenres();
            return genres;
        }
    }
}