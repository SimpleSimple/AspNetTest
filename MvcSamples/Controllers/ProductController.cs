using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MvcSamples.Controllers
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductController : ApiController
    {
        public IEnumerable<Products> GetAllProducts()
        {
            return new List<Products>() {

               new Products() {Id = 1, Name = "Cookie 1", Price = 1.99D},

               new Products() {Id = 2, Name = "Cookie 2", Price = 2.99D},

               new Products(){Id = 3, Name = "Cookie 3", Price = 3.99D}

            };
        }

        // GET api/product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/product
        public void Post([FromBody]string value)
        {
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
        }
    }
}
