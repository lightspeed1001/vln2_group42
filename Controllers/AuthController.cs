using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCave.Controllers
{
    public class AuthController
    {
        private readonly ICustomerServices _customerService;

        public AuthController(ICustomerServices customerServices)
        {
            _customerService = customerServices;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public UserView Login(UserLoginView user)
        {
            bool isValidLogin = _customerService.CheckLogin(user);

            if(isValidLogin)
            {
                return _customerService.getUser(user.Email);
            }

            return null;
        }
    }
}
