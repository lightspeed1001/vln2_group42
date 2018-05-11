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

        public IEnumerable<OrderView> GetOrdersForUser(int userID)
        {
            var orders = (from o in _db.Orders where o.CustomerID == userID select GetViewForEntity(o));
            return orders;
        }

        public void AddBookToOrder(int bookID, int orderID)
        {
            BookInOrder bookInOrder = new BookInOrder{BookID = bookID, OrderID = orderID};
            _db.Add(bookInOrder);

             _db.SaveChanges();
        }

        public void RemoveBookFromOrder(int bookID, int orderID)
        {
            var bookInOrder = (from bo in _db.BooksInOrders
                                where bo.BookID == bookID && bo.OrderID == orderID
                                select bo).Single();
            _db.Remove(bookInOrder);
            _db.SaveChanges();
        }

        public void AddBooksToOrder(IEnumerable<int> bookIDs, int orderID)
        {
            foreach (var bookID in bookIDs)
            {
                AddBookToOrder(bookID, orderID);
            }
        }

        //Returns the ID of the new order
        public int AddOrder(NewOrderView order)
        {
            Order orderEntity = new Order
            {
                CustomerID = order.OwnerID,
                ShippingCost = order.ShippingCost
            };
            var derp = _db.Add(orderEntity);
            _db.SaveChanges();
            return derp.Entity.ID;
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
            var orderEntity = _db.Orders.Single(x => x.ID == order.ID);
            orderEntity.DateCompleted = order.DateCompleted;
            orderEntity.ShippingCost = order.ShippingCost;
            orderEntity.Status = order.Status;

            _db.SaveChanges();
        }

        public IEnumerable<BookInOrderView> GetAllBooksForOrder(OrderView order)
        {
            return GetAllBooksForOrder(order.ID);
        }

        public IEnumerable<BookInOrderView> GetAllBooksForOrder(Order order)
        {
            return GetAllBooksForOrder(order.ID);
        }

        public IEnumerable<BookInOrderView> GetAllBooksForOrder(int orderID)
        {
            BookRepository bookRepo = new BookRepository();
            var books = (from bo in _db.BooksInOrders
                         where bo.OrderID == orderID
                         select new BookInOrderView
                         {
                             OrderID = orderID,
                             BookID = bo.BookID,
                             Price = bo.Price,
                             Book = bookRepo.GetShortBookViewByID(bo.BookID),
                             NumberOfCopies = bo.NumberOfCopies
                         });
            
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
                OwnerID = order.CustomerID,
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