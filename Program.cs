using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Repositories;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        

        

        public static void SeedData()
        {
            //DO NOT RUN THIS SECTION WITHOUT APPROVAL
            return;
            
            /*List<Book> books = new List<Book>
            {
                new Book{ Title = "Book 1", Price = 10f, ISBN = "legitisbn1"},
                new Book{ Title = "Book 2", Price = 20f, ISBN = "legitisbn2"},
                new Book{ Title = "Book 3", Price = 30f, ISBN = "legitisbn3"},
                new Book{ Title = "Book 4", Price = 40f, ISBN = "legitisbn4"}
            };

            List<Author> authors = new List<Author>
            {
                new Author{ Name = "Author 1" },
                new Author{ Name = "Author 2" },
                new Author{ Name = "Author 3" },
                new Author{ Name = "Author 4" },
                new Author{ Name = "Author 5" }
            };

            List<Customer> customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1", Email = "a@a.is"},
                new Customer{ Name = "Customer 2", Email = "b@b.is"},
                new Customer{ Name = "Customer 3", Email = "c@c.is"},
                new Customer{ Name = "Customer 4", Email = "d@d.is"},
                new Customer{ Name = "Customer 5", Email = "e@e.is"},
                new Customer{ Name = "Customer 6", Email = "f@f.is"}
            };

            List<Genre> genres = new List<Genre>
            {
                new Genre{ Name = "Genre 1"},
                new Genre{ Name = "Genre 2"},
                new Genre{ Name = "Genre 3"},
                new Genre{ Name = "Genre 4"},
                new Genre{ Name = "Genre 5"}
            };

            List<BookReview> reviews = new List<BookReview>
            {
                new BookReview{ CustomerID = 1, BookID = 1, Rating = 10 },
                new BookReview{ CustomerID = 1, BookID = 2, Rating = 9 },
                new BookReview{ CustomerID = 1, BookID = 3, Rating = 8 },
                new BookReview{ CustomerID = 2, BookID = 1, Rating = 7 },
                new BookReview{ CustomerID = 3, BookID = 1, Rating = 6 },
                new BookReview{ CustomerID = 4, BookID = 1, Rating = 5 },
                new BookReview{ CustomerID = 4, BookID = 2, Rating = 4 },
                new BookReview{ CustomerID = 5, BookID = 1, Rating = 3 }
            };

            List<BookAuthor> bookAuthors = new List<BookAuthor>
            {
                new BookAuthor{AuthorID = 1, BookID = 1},
                new BookAuthor{AuthorID = 2, BookID = 2},
                new BookAuthor{AuthorID = 2, BookID = 3},
                new BookAuthor{AuthorID = 1, BookID = 4},
                new BookAuthor{AuthorID = 2, BookID = 5},
                new BookAuthor{AuthorID = 3, BookID = 3}
            };

            List<BookGenre> bookGenres = new List<BookGenre>
            {
                new BookGenre{GenreID = 1, BookID = 1},
                new BookGenre{GenreID = 2, BookID = 2},
                new BookGenre{GenreID = 3, BookID = 3},
                new BookGenre{GenreID = 4, BookID = 3},
                new BookGenre{GenreID = 5, BookID = 4},
                new BookGenre{GenreID = 4, BookID = 4},
            };

            DataContext db = new DataContext();
            db.AddRange(books);
            db.AddRange(authors);
            db.AddRange(customers);
            db.AddRange(genres);
            db.AddRange(reviews);
            db.AddRange(bookAuthors);
            db.AddRange(bookGenres);
            db.SaveChanges();*/
        }
    }
}
