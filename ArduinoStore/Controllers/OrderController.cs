using ArduinoStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            OrderModel orderModel = new OrderModel();
            orderModel.Orders = new List<Order>();
            int accountId = HttpContext.Session.Get<int>("_AccountId");
            bool isPremiumAccount = HttpContext.Session.Get<bool>("_PremiumAccount");
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT o.OrdersId, SUM(p.Price * op.Quantity) AS Total FROM Orders o JOIN OrderProduct op ON o.OrdersId = op.OrdersID JOIN Product p ON op.ProductId = p.ProductId WHERE o.AccountId = {accountId} GROUP BY o.OrdersId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int orderId = int.Parse(dr["OrdersId"].ToString());
                            decimal total = decimal.Parse(dr["Total"].ToString());
                            if (!isPremiumAccount)
                                total += 2;
                            orderModel.Orders.Add(new Order
                            {
                                OrderId = orderId,
                                Total = total
                            }
                            );
                        }
                        return View(orderModel);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
            return View();
        }
    }
}
