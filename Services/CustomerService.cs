using System;
using System.Security.Cryptography;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CustomerService : ICustomerServices
    {
        private readonly ICustomerRepositorys _customerRepositorys;

        public CustomerService(ICustomerRepositorys customerRepositorys)
        {
            _customerRepositorys = customerRepositorys;
        }

        public void CreateNewUser(NewUserView newUser)
        {

        }

        public void EditUser(UserEditView user)
        {

        }

        public bool CheckLogin(UserLoginView user)
        {
            return _customerRepositorys.isUser(user.Email, user.Password);
        }

        public UserView getUser(string username)
        {
            return _customerRepositorys.getUser(username);
        }
    }
}