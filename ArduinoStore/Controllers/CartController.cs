using ArduinoStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            CartModel cartModel = new CartModel();
            cartModel.Total = 0;
            string cartJson = HttpContext.Session.Get<string>("_CartItems");
            List<ProductModel> cartItems = JsonConvert.DeserializeObject<List<ProductModel>>(cartJson);
            cartModel.Products = cartItems;
            foreach(ProductModel product in cartModel.Products)
            {
                cartModel.Total += product.Price * product.CartCount;
            }
            bool isPremiumAccount = HttpContext.Session.Get<bool>("_PremiumAccount");
            if(isPremiumAccount)
            {
                cartModel.DeliveryFee = 0;
            }
            else
            {
                cartModel.DeliveryFee = 2;
                cartModel.Total += 2;
            }
            return View(cartModel);
        }

        [HttpPost]
        public IActionResult Finish(decimal total, string address)
        {
            string cartJson = HttpContext.Session.Get<string>("_CartItems");
            List<ProductModel> cartItems = JsonConvert.DeserializeObject<List<ProductModel>>(cartJson);
            int accountId = HttpContext.Session.Get<int>("_AccountId");
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"INSERT INTO Orders VALUES({accountId}, '{address}'); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int orderId = int.Parse(dr[0].ToString());
                        foreach(ProductModel product in cartItems)
                        {
                            dr.Close();
                            query = $"INSERT INTO OrderProduct VALUES({orderId}, {product.ProductID}, {product.CartCount}); SELECT SCOPE_IDENTITY()";
                            cmd = new SqlCommand(query, conn);
                            dr = cmd.ExecuteReader();
                            if(!dr.Read())
                            {
                                return NotFound();
                            }
                        }
                        conn.Close();
                        cartItems = new List<ProductModel>();
                        string cartItemsJson = JsonConvert.SerializeObject(cartItems);
                        HttpContext.Session.Set<string>("_CartItems", cartItemsJson);
                    }
                    else
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }
    }
}
