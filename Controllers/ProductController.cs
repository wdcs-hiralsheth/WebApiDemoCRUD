using Plivo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDemo_1_12.Models;
namespace WebApiDemo_1_12.Controllers
{
    public class ProductController : ApiController
    {
        Entities db = new Entities();
        //add post request
        [HttpPost]
        public string Post(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return "Product Added";
        }
        //return otp api
        //[HttpGet]
        //public string GenerateOtp(string mobileno,string username,string api_password,string sender, string to,string message,string priority,string e_id,string t_id)
        //{

        //    Random rnd = new Random();
        //    var otp = rnd.Next(100000, 999999).ToString();
        //  //  var api = new PlivoApi("MAYMMYNDGZMGMWMDASNT","ODg");
        //    //var response = api.Message.Create(
        //    //    src:"SARPANCH",
        //    //    dst:"+91"+mobileno,
        //    //    text:otp
        //    //    //to: new List<String> { "<Caller_ID>" },
        //    //    //from: "<Destination_Number>",
        //    //    //answerMethod: "GET",
        //    //    //answerUrl: "http://s3.amazonaws.com/static.plivo.com/answer.xml"
        //    //);
        //   //// Console.WriteLine(response);
        //   // HttpContext.Current.Session["TestSessionValue"] = null;
        //   // HttpContext.Current.Session.Add("OTP", otp);
        //   // string a = "OTP send to your Registered mobile number";


        //    return otp;
        //}
        
        //[HttpPost]
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> Post([FromBody] Product product)
        //{


        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {

        //        throw;

        //    }

        //    return Ok(product); ;
        //}
        //get all records
        public IEnumerable<Product> Get() 
        {
            return db.Products.ToList();
        }

        //get single product
        public Product Get(int Id) {
          Product product=  db.Products.Find(Id);
          return product;
        }

        //update the record
        public string Put(int id,Product product)
        {
            var product_ = db.Products.Find(id);
            product_.Name = product.Name;
            product_.Price = product.Price;
            product_.Quantity = product.Quantity;
            product_.Active = product.Active;

            db.Entry(product_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return "Product Updated.";
        }
        
        //delete the record
        public string Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return "Product Deleted";
        }

    }

}
