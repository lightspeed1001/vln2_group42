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
            throw new NotImplementedException();
        }

        public List<OrderView> GetOrdersForUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(OrderView order)
        {
            throw new NotImplementedException();
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
    }
}