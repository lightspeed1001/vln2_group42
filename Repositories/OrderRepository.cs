using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderRepository
    {
        private DataContext _db;

        public OrderRepository()
        {
            _db = new DataContext();
        }

        public OrderView GetOrderByID(int id)
        {
            OrderView order = GetViewForEntity(_db.Orders.Single(x => x.ID == id));
            return order;
        }

        public List<OrderView> GetOrdersForUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(OrderView order)
        {
            Order orderEntity = GetEntityForView(order);
            _db.Add(orderEntity);
            _db.SaveChanges();
        }

        public void RemoveOrder(OrderView order)
        {
            RemoveOrderByID(order.ID);
        }

        public void RemoveOrderByID(int orderID)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(OrderView order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShortBookView> GetAllBooksForOrder(OrderView order)
        {
            return GetAllBooksForOrder(order.ID);
        }

        public IEnumerable<ShortBookView> GetAllBooksForOrder(Order order)
        {
            return GetAllBooksForOrder(order.ID);
        }

        public IEnumerable<ShortBookView> GetAllBooksForOrder(int orderID)
        {
            BookRepository bookRepo = new BookRepository();
            var books = (from b in _db.Books
                         join bo in _db.BooksInOrders on b.ID equals bo.BookID
                         where bo.OrderID == orderID
                         select bookRepo.GetShortViewForEntity(b));
            return books;
        }

        public float GetPriceForBookInOrder(int bookID, int orderID)
        {
            var derp = (from bo in _db.BooksInOrders 
                        where bo.BookID == bookID && bo.OrderID == orderID
                        select bo.Price).Single();
            return derp;
        }

        public float GetPriceForOrder(int orderID, float shipping)
        {
            var derp = (from bo in _db.BooksInOrders select bo.Price).DefaultIfEmpty(0).Sum() + shipping;
            return derp;
        }

        public OrderView GetViewForEntity(Order order)
        {
            CustomerRepository customerRepo = new CustomerRepository();
            OrderView orderView = new OrderView
            {
                Books = GetAllBooksForOrder(order.ID),
                ID = order.ID,
                Owner = customerRepo.GetUserViewForID(order.CustomerID),
                Status = order.Status,
                DateCompleted = order.DateCompleted,
                ShippingCost = order.ShippingCost
            };
            return orderView;
        }

        public Order GetEntityForView(OrderView order)
        {
            Order orderEntity = new Order
            {
                CustomerID = order.Owner.ID,
                ID = order.ID,
                Status = order.Status,
                ShippingCost = order.ShippingCost,
                DateCompleted = order.DateCompleted
            };
            return orderEntity;
        }
    }
}