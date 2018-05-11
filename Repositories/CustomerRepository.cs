using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class CustomerRepository
    {
        private DataContext _db;

        public CustomerRepository()
        {
            _db = new DataContext();
        }

        //Login will probably be email based?
        public bool IsUniqueEmail(string email)
        {
            bool isUniqueEmail = (from x in _db.Customers where x.Email == email select x).Count() == 0;

            return isUniqueEmail;
        }

        public void EditUser(UserEditView user)
        {
            Customer c = (from u in _db.Customers where u.ID == user.ID select u).SingleOrDefault();
            if(c == null) return;
            c.Address = user.Address;
            c.CardExpiry = user.CardExp;
            c.CardNumber = user.CardNum;
            c.Country = user.Country;
            if(IsUniqueEmail(user.Email))
                c.Email = user.Email;
            c.HashedPassword = user.Password;
            c.Name = user.Name;
            c.PhoneNumber = user.PhoneNumber;
            c.Postcode = user.Postcode;
            _db.SaveChanges();
        }

        //Lazy method. Doesn't clean up properly etc
        public void RemoveCustomer(int customerID)
        {
            Customer customerEntity = _db.Customers.SingleOrDefault(x => x.ID == customerID);
            if(customerEntity != null) 
            {
                _db.Remove(customerEntity);
                _db.SaveChanges();
            }
        }

        public void AddUser(NewUserView user)
        {
            Customer newUser = new Customer
            {
                Address = user.Address,
                CardExpiry = user.CardExpiry,
                CardNumber = user.CardNumber,
                Country = user.Country,
                Email = user.Email,
                HashedPassword = user.Password, //lol
                IsStaff = false,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Postcode = user.Postcode
            };
            _db.Add(newUser);
        }

        //Intended for the user control panel
        public UserEditView GetUserEditViewForID(int id)
        {
            var users = (from u in _db.Customers where u.ID == id select 
                        new UserEditView
                        {
                            Address = u.Address,
                            CardExp = u.CardExpiry, 
                            CardNum = u.CardNumber, //lol
                            Country = u.Country,
                            Email = u.Country,
                            ID = u.ID,
                            Name = u.Name,
                            Password = u.HashedPassword,
                            PhoneNumber = u.PhoneNumber,
                            Postcode = u.Postcode
                        });
            return users.SingleOrDefault();
        }

        //idk, can probably find a use for this
        public UserView GetUserViewForID(int id)
        {
            var users = (from u in _db.Customers where u.ID==id select
                    new UserView
                    {
                        ID = u.ID,
                        Name = u.Name,
                        Email = u.Email,
                        Address = u.Address,
                        Country = u.Country,
                        Postcode = u.Postcode,
                        PhoneNumber = u.PhoneNumber
                    });
            return users.SingleOrDefault();
        }
    }
}