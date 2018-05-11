using BookCave.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Services
{
    public interface ICustomerServices
    {
        void CreateNewUser(NewUserView newUser);

        UserView getUser(string username);

        void EditUser(UserEditView user);

        bool CheckLogin(UserLoginView user);
    }
}
