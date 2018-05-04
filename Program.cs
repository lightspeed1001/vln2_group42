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
            SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        public static void SeedData()
        {
            return;
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
