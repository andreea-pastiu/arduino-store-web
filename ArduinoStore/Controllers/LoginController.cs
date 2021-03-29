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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        string query = $"SELECT a.AccountId FROM Account a JOIN Administrator ad on a.AccountId = ad.AccountId WHERE a.Username = '{model.Username}' AND a.Password = '{model.Password}'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            int userID = int.Parse(dr["AccountId"].ToString());
                            HttpContext.Session.Set<int>("_AdminId", userID);
                            conn.Close();
                            return RedirectToAction("index", "admin");
                        }
                        else
                        {
                            dr.Close();
                            query = $"SELECT a.AccountId, c.PremiumAccount FROM Account a JOIN Customer c on a.AccountId = c.AccountId WHERE a.Username = '{model.Username}' AND a.Password = '{model.Password}'";
                            cmd = new SqlCommand(query, conn);
                            dr = cmd.ExecuteReader();
                            {
                                if (dr.HasRows)
                                {
                                    dr.Read();
                                    int userID = int.Parse(dr["AccountId"].ToString());
                                    bool isPremium = bool.Parse(dr["PremiumAccount"].ToString());
                                    HttpContext.Session.Set<int>("_AccountId", userID);
                                    HttpContext.Session.Set<bool>("_PremiumAccount", isPremium);
                                    List<ProductModel> cartItems = new List<ProductModel>();
                                    string cartItemsJson = JsonConvert.SerializeObject(cartItems);
                                    HttpContext.Session.Set<string>("_CartItems", cartItemsJson);
                                    conn.Close();
                                    return RedirectToAction("index", "customer");
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Set<int>("_AccountId", 0);
            HttpContext.Session.Set<int>("_AdminId", 0);
            return Ok();
        }
    }
}
