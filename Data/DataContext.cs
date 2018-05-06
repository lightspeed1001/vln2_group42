using Microsoft.EntityFrameworkCore;
using BookCave.Data.EntityModels;

namespace BookCave.Data
{
    public class DataContext : DbContext
    {
        //Data tables
        public DbSet<Author>        Authors   {get; set;}
        public DbSet<Book>          Books     {get; set;}
        public DbSet<Genre>         Genres    {get; set;}
        public DbSet<Order>         Orders    {get; set;}
        public DbSet<CustomerList>  Lists     {get; set;}
        public DbSet<BookReview>    Reviews   {get; set;}
        public DbSet<Customer>      Customers {get; set;}
        
        //Relationship tables
        public DbSet<BookAuthor>    BookAuthors     {get; set;}
        public DbSet<BookGenre>     BookGenres      {get; set;}
        public DbSet<BookInOrder>   BooksInOrders   {get; set;}
        public DbSet<BooksInList>   BooksInLists    {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H42;Persist Security Info=False;User ID=VLN2_2018_H42_usr;Password=sw3etEnd81;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Pure join tables, don't need ID
            modelBuilder.Entity<BookGenre>().HasKey(t => new {t.BookID, t.GenreID});
            modelBuilder.Entity<BookAuthor>().HasKey(t => new {t.BookID, t.AuthorID});
            modelBuilder.Entity<BooksInList>().HasKey(k => new {k.BookID, k.ListID});
            modelBuilder.Entity<BookInOrder>().HasKey(k => new{k.BookID, k.OrderID});

            // Tried to get fancy with the tables, wasn't worth it
            // modelBuilder.Entity<BookGenre>()
            //                 .HasOne(b => b.Book)
            //                 .WithMany(b => b.BookGenres)
            //                 .HasForeignKey(b => b.BookID);
            // modelBuilder.Entity<BookGenre>()
            //                 .HasOne(g => g.Genre)
            //                 .WithMany(g => g.BookGenres)
            //                 .HasForeignKey(g => g.GenreID);

            // modelBuilder.Entity<BookAuthor>()
            //                 .HasOne(b => b.Book)
            //                 .WithMany(b => b.BookAuthors)
            //                 .HasForeignKey(b => b.BookID);
            // modelBuilder.Entity<BookAuthor>()
            //                 .HasOne(g => g.Author)
            //                 .WithMany(g => g.BookAuthors)
            //                 .HasForeignKey(g => g.AuthorID);

            // modelBuilder.Entity<BooksInList>()
            //                 .HasOne(b => b.Book)
            //                 .WithMany(b => b.BooksInList)
            //                 .HasForeignKey(b => b.BookID);
            // modelBuilder.Entity<BooksInList>()
            //                 .HasOne(l => l.List)
            //                 .WithMany(l => l.BooksInList)
            //                 .HasForeignKey(l => l.ListID);

            // modelBuilder.Entity<BookInOrder>()
            //                 .HasOne(b => b.Book)
            //                 .WithMany(b => b.BooksInOrder)
            //                 .HasForeignKey(b => b.BookID);
            // modelBuilder.Entity<BookInOrder>()
            //                 .HasOne(o => o.Order)
            //                 .WithMany(o => o.BooksInOrder)
            //                 .HasForeignKey(o => o.OrderID);
        }
    }
}