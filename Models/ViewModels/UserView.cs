using System;
using System.Collections.Generic;
// using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class UserView
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; }
        public string PhoneNumber {get; set; }
    }
}