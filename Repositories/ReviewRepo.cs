using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class ReviewRepository
    {
        private DataContext _db;

        public ReviewRepository()
        {
            _db = new DataContext();
        }

        public List<ReviewView> GetAllReviewsForBook(BookView book)
        {
            return GetAllReviewsForBook(book.ID);
        }

        public List<ReviewView> GetAllReviewsForBook(ShortBookView book)
        {
            return GetAllReviewsForBook(book.BookID);
        }

        public List<ReviewView> GetAllReviewsForBook(int bookID)
        {
            throw new NotImplementedException();
        }
        public List<ReviewView> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public void AddReview(ReviewView Review)
        {
            throw new NotImplementedException();
        }

        public void RemoveReview(ReviewView Review)
        {
            RemoveReviewByID(Review.ID);
        }

        public void RemoveReviewByID(int id)
        {
            throw new NotImplementedException();
        }

        public void EditReview(ReviewView Review)
        {
            throw new NotImplementedException();
        }
    }
}