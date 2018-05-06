using System;
using System.Security.Cryptography;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CustomerService
    {
    
        public static void CreateNewUser(NewUserView newUser)
        {
            //CustomerRepository repo = new CustomerRepository();
            //repo.AddUser(newUser);
        }

        public static void EditUser(UserEditView user)
        {
            CustomerRepository repo = new CustomerRepository();
            repo.EditUser(user);
        }

        public static bool CheckLogin(UserLoginView user)
        {
            
            return false;
        }
    }
}