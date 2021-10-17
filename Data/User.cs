using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeDeliveryApp.Data
{
   public  class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }


        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
       
    }
}
