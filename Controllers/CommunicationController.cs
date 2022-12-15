using Plivo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDemo_1_12.Models;

namespace WebApiDemo_1_12.Controllers
{
    public class CommunicationController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GenerateOtp(string mobileno, string username, string api_password, string sender, string to,string priority,string e_id,string t_id)
        {

            Random rnd = new Random();
            var otp = rnd.Next(100000, 999999).ToString();
            string URL = "";
            string MainUrl = "pushsms.php?";
            string Message =null;
            Message = "Dear Customer,"+ otp + "is your OTP to register on Post It. Use this code to validate your Sign Up. It will valid till 03 minutes. Code One Zero Technologies Private Limited";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.bulk-sms.in/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                URL = MainUrl + "username=" + User + "&api_password=" + api_password + "&sender=" + sender + "&message=" + HttpUtility.UrlEncode(Message).Trim() + "&priority=" + priority + "&e_id=" +e_id+"&t_id="+t_id;
                
                HttpResponseMessage response = await client.GetAsync(URL);
                if (response.IsSuccessStatusCode)
                {
                    return Ok(otp);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            
            return Ok("Internal server Error");

        }

        //public string GenerateOtp(string mobileno, string username, string api_password, string sender, string to, string message, string priority, string e_id, string t_id)
        //{

        //    Random rnd = new Random();
        //    var otp = rnd.Next(100000, 999999).ToString();
        //    // var api = new PlivoApi("", "");
        //    //    var product_ = db.Products.Find(id);
        //    //    product_.Name = product.Name;
        //    //    product_.Price = product.Price;
        //    //    product_.Quantity = product.Quantity;
        //    //    product_.Active = product.Active;

        //    //    db.Entry(product_).State = System.Data.Entity.EntityState.Modified;
        //    //    db.SaveChanges();

        //    return otp;
        //}

    }
}
