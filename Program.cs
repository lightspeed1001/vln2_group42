using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
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
            // SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        public static void SeedData()
        {
            return;
            
            /*DataContext db = new DataContext();

            List<Customer> customers = new List<Customer>()
            {
                new Customer { Name = "Customer the First"  },
                new Customer { Name = "Customer the Second" },
                new Customer { Name = "Customer the Third"  },
                new Customer { Name = "Customer the Fourth" }
            };

            List<BookReview> reviews = new List<BookReview>()
            {
                new BookReview { BookID = 1, CustomerID = 1, Rating = 10 },
                new BookReview { BookID = 1, CustomerID = 2, Rating = 9  },
                new BookReview { BookID = 1, CustomerID = 3, Rating = 3  },
                new BookReview { BookID = 1, CustomerID = 4, Rating = 5  }
            };

            List<BookAuthor> bookauthors = new List<BookAuthor>()
            {
                new BookAuthor { BookID = 1, AuthorID = 2 }
            };

            db.AddRange(customers);
            db.AddRange(reviews);
            db.AddRange(bookauthors);

            db.SaveChanges();

            /*var db = new DataContext();

            List<Book> books = new List<Book>()
            {
                new Book { Title = "Book Uno" },
                new Book { Title = "Book Dos" },
                new Book { Title = "Book Tres"}
            };
            List<Author> authors = new List<Author>()
            {
                new Author { Name = "Author One"  },
                new Author { Name = "Author Two"  },
                new Author { Name = "Author Three"}
            };
            books[0].BookAuthors = new List<BookAuthor>() { new BookAuthor {BookID = 1, AuthorID = 1}};
            
            db.AddRange(authors);
            db.AddRange(books);
            db.SaveChanges();*/
        }
    }
}
