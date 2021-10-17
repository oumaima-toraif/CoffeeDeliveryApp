using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyWebApi.Models;
namespace MyWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private COFEEDELIVEntities1 db = new COFEEDELIVEntities1();
        [Route("api/values/getProducts")]
        [HttpGet]
        public List<Product> Get()
        {
            //return new string[] { "value1", "value2" };
            List<Product> products = db.PRODUCTs.Select(p =>
                new Product()
                {
                    ProducTID = p.ProductID,
                    Name = p.Name,
                    Description = p.Description,
                    Photo = p.Photo,
                    price = p.Price
                })
                  .ToList();
            return products;






        }

        [Route("api/values/getProduct")]
        [HttpGet]
        public Product Get(int id)
        {
            Product product = db.PRODUCTs.Select(p =>
              new Product()
              {
                  ProducTID = p.ProductID,
                  Name = p.Name,
                  Description = p.Description,
                  Photo = p.Photo,
                  price = p.Price
              })
                .FirstOrDefault(p => p.ProducTID == id);
            return product;
        }


        [Route("api/values/UserSignUp")]
        [HttpPost]
        public void Post([FromBody] User u)
        {
            USER user = new USER();
            user.Username = u.Username;
            user.Phone = u.Phone;
            user.Password = u.Password;
            user.ConfirmPassword = u.ConfirmPassword;
           
            db.USERs.Add(user);
            db.SaveChanges();
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }



        [Route("api/values/CheckUsername")]
        [HttpPost]
        public bool CheckUsername([FromBody] User u1)
        {
            User user = db.USERs.Select(u =>
              new User()
              {
                  Username = u.Username,
                  UserID=u.UserID
                 


              }).FirstOrDefault(u =>u.Username == u1.Username);

            if (user==null)
            {
                return false;
            }
            else {
                return true;
            }

           
        }

        [Route("api/values/CheckUser")]
        [HttpPost]
        public User CheckUser([FromBody] User LoginUser) {
            User user = db.USERs.Select(u =>
              new User()
              {
                  UserID=u.UserID,
                  Username = u.Username,
                  Password=u.Password,
                  ConfirmPassword=u.ConfirmPassword,
                  Phone=u.Phone
                 


              }).FirstOrDefault(u => u.Username ==LoginUser.Username && u.Password==LoginUser.Password);
            return user;
           
        }
        [Route("api/values/getUserProfile")]
        [HttpGet]
        public User getUserProfile(int id)
        {
            User user= db.USERs.Select(u =>
              new User()
              {
                  UserID=u.UserID,
                  Username=u.Username,
                  Phone=u.Phone,
                  Password=u.Password
              })
                .FirstOrDefault(u=> u.UserID== id);
            return user;
        }
    }
}
