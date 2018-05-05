using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Data.EntityModels
{
    public class Customer
    {
        public int ID {get; set;}

        [Required]
        public string Name {get; set;}

        //[Required]
        public string Password {get; set;}

        //[Required]
        public string Salt {get; set;}
        
        //[Required]
        public string Email {get; set;}
        public string Address {get; set;}
        public string Country {get; set;}
        public string Postcode {get; set;}
        public string CardNumber {get; set;}
        public string CardExpiry {get; set;}
        public string PhoneNumber {get; set;}

        // public List<BookReview> Reviews {get; set;}
        // public List<CustomerList> Lists {get; set;}
        // public List<Order> Orders {get; set;}
    }
}