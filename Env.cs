using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeDeliveryApp
{
   public  class Env
    {
        public static string ip = "192.168.1.106";
        public static string WebAplication = "http://" + ip + "/MyWebApi/";

        public static string getProducts = WebAplication + "api/values/getProducts";
        public static string getProduct = WebAplication + "api/values/getProduct";
        public static string CheckUsername = WebAplication + "api/values/CheckUsername";
       
        public static string CheckUser = WebAplication + "api/values/CheckUser";
        public static string UserSignUp = WebAplication + "api/values/UserSignUp";
        public static string getUserProfile = WebAplication + "api/values/getUserProfile";
    }
}
