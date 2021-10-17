using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeDeliveryApp.Data
{
   public  class Commande
    {
        public int ProducTID { get; set; }
        public int CommandeID { get; set; }
        public int UserID{ get; set; }
        public DateTime date{ get; set; }
       
    }
}
