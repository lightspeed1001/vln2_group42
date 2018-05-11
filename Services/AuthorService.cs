using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AuthorService
    {
        public AuthorRepository _authorRepo;
        public AuthorService()
        {
            _authorRepo = new AuthorRepository();
        }
        public AuthorView GetAuthorByID(int? id)
        {
            return _authorRepo.GetAuthorByID(id);
        }
    }
}