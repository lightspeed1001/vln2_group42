using BookCave.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Repositories
{
    public interface ICustomerRepositorys
    {
        bool isUser(string username, string password);

        UserView getUser(string username);

        bool IsUniqueEmail(string email);

        void EditUser(UserEditView user);

        void RemoveCustomer(int customerID);

        void AddUser(NewUserView user);

        UserEditView GetUserEditViewForID(int id);

        UserView GetUserViewForID(int id);
    }
}
