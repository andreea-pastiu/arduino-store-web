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
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            return View();
        }

        public IActionResult Board()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            CustomerBoardModel customerBoard = new CustomerBoardModel();
            customerBoard.ArduinoBoards = new List<AddBoardModel>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT p.Price, p.ProductImage, c.Name, p.Model, ab.* FROM Product p JOIN ArduinoBoard ab ON p.ProductId = ab.ProductId JOIN Company c ON p.CompanyId = c.CompanyId WHERE p.IsDeleted = 0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int productId = int.Parse(dr["ProductId"].ToString());
                            decimal price = decimal.Parse(dr["Price"].ToString());
                            string companyName = dr["Name"].ToString();
                            string model = dr["Model"].ToString();
                            string productImage = dr["ProductImage"].ToString();
                            decimal supplyVoltage = decimal.Parse(dr["SupplyVoltage"].ToString());
                            int digitalPins = int.Parse(dr["DigitalPins"].ToString());
                            int analogPins = int.Parse(dr["AnalogPins"].ToString());
                            decimal flashMemory = decimal.Parse(dr["FlashMemory"].ToString());
                            decimal frequency = decimal.Parse(dr["Frequency"].ToString());
                            customerBoard.ArduinoBoards.Add(new AddBoardModel
                            {
                                ProductID = productId,
                                Price = price,
                                CompanyName = companyName,
                                Model = model,
                                SupplyVoltage = supplyVoltage,
                                DigitalPins = digitalPins,
                                AnalogPins = analogPins,
                                FlashMemory = flashMemory,
                                Frequency = frequency,
                                ProductImage = productImage
                            }
                            );
                        }
                        return View(customerBoard);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Breadboard()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            CustomerBreadboardModel customerBreadboard = new CustomerBreadboardModel();
            customerBreadboard.Breadboards = new List<AddBreadboardModel>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT p.Price, p.ProductImage, c.Name, p.Model, b.* FROM Product p JOIN Breadboard b ON p.ProductId = b.ProductId JOIN Company c ON p.CompanyId = c.CompanyId WHERE p.IsDeleted = 0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int productId = int.Parse(dr["ProductId"].ToString());
                            decimal price = decimal.Parse(dr["Price"].ToString());
                            string companyName = dr["Name"].ToString();
                            string model = dr["Model"].ToString();
                            string productImage = dr["ProductImage"].ToString();
                            int width = int.Parse(dr["Width"].ToString());
                            int length = int.Parse(dr["Length"].ToString());
                            int tiePoints = int.Parse(dr["TiePoints"].ToString());
                            customerBreadboard.Breadboards.Add(new AddBreadboardModel
                            {
                                ProductID = productId,
                                Price = price,
                                CompanyName = companyName,
                                Model = model,
                                Width = width,
                                Length = length,
                                TiePoints = tiePoints,
                                ProductImage = productImage
                            }
                            );
                        }
                        return View(customerBreadboard);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult LED()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            CustomerLEDModel customerLED = new CustomerLEDModel();
            customerLED.LEDs = new List<AddLEDModel>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT p.Price, p.ProductImage, c.Name, p.Model, l.* FROM Product p JOIN Led l ON p.ProductId = l.ProductId JOIN Company c ON p.CompanyId = c.CompanyId WHERE p.IsDeleted = 0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int productId = int.Parse(dr["ProductId"].ToString());
                            decimal price = decimal.Parse(dr["Price"].ToString());
                            string companyName = dr["Name"].ToString();
                            string model = dr["Model"].ToString();
                            string productImage = dr["ProductImage"].ToString();
                            string color = dr["Color"].ToString();
                            int diameter = int.Parse(dr["Diameter"].ToString());
                            decimal current = decimal.Parse(dr["LEDCurrent"].ToString());
                            customerLED.LEDs.Add(new AddLEDModel
                            {
                                ProductID = productId,
                                Price = price,
                                CompanyName = companyName,
                                Model = model,
                                Color = color,
                                Diameter = diameter,
                                Current = current,
                                ProductImage = productImage
                            }
                            );
                        }
                        return View(customerLED);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Motor()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            CustomerMotorModel customerMotor = new CustomerMotorModel();
            customerMotor.Motors = new List<AddMotorModel>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT p.Price, p.ProductImage, c.Name, p.Model, m.* FROM Product p JOIN Motor m ON p.ProductId = m.ProductId JOIN Company c ON p.CompanyId = c.CompanyId WHERE p.IsDeleted = 0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int productId = int.Parse(dr["ProductId"].ToString());
                            decimal price = decimal.Parse(dr["Price"].ToString());
                            string companyName = dr["Name"].ToString();
                            string model = dr["Model"].ToString();
                            string productImage = dr["ProductImage"].ToString();
                            decimal voltage = decimal.Parse(dr["Voltage"].ToString());
                            decimal current = decimal.Parse(dr["MotorCurrent"].ToString());
                            decimal rotationSpeed = decimal.Parse(dr["RotationSpeed"].ToString());
                            customerMotor.Motors.Add(new AddMotorModel
                            {
                                ProductID = productId,
                                Price = price,
                                CompanyName = companyName,
                                Model = model,
                                Voltage = voltage,
                                Current = current,
                                RotationSpeed = rotationSpeed,
                                ProductImage = productImage
                            }
                            );
                        }
                        return View(customerMotor);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Sensor()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            CustomerSensorModel customerSensor = new CustomerSensorModel();
            customerSensor.Sensors = new List<AddSensorModel>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT p.Price, p.ProductImage, c.Name, p.Model, s.* FROM Product p JOIN Sensor s ON p.ProductId = s.ProductId JOIN Company c ON p.CompanyId = c.CompanyId WHERE p.IsDeleted = 0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int productId = int.Parse(dr["ProductId"].ToString());
                            decimal price = decimal.Parse(dr["Price"].ToString());
                            string companyName = dr["Name"].ToString();
                            string model = dr["Model"].ToString();
                            string productImage = dr["ProductImage"].ToString();
                            string type = dr["Type"].ToString();
                            decimal voltage = decimal.Parse(dr["Voltage"].ToString());
                            bool digitalPin = bool.Parse(dr["DigitalPin"].ToString());
                            bool analogPin = bool.Parse(dr["AnalogPin"].ToString());
                            customerSensor.Sensors.Add(new AddSensorModel
                            {
                                ProductID = productId,
                                Price = price,
                                CompanyName = companyName,
                                Model = model,
                                Type = type,
                                Voltage = voltage,
                                DigitalPin = digitalPin,
                                AnalogPin = analogPin,
                                ProductImage = productImage
                            }
                            );
                        }
                        return View(customerSensor);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult WireSet()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            CustomerWireSetModel customerWireSet = new CustomerWireSetModel();
            customerWireSet.WireSets = new List<AddWireSetModel>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT p.Price, p.ProductImage, c.Name, p.Model, ws.* FROM Product p JOIN WireSet ws ON p.ProductId = ws.ProductId JOIN Company c ON p.CompanyId = c.CompanyId WHERE p.IsDeleted = 0";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int productId = int.Parse(dr["ProductId"].ToString());
                            decimal price = decimal.Parse(dr["Price"].ToString());
                            string companyName = dr["Name"].ToString();
                            string model = dr["Model"].ToString();
                            string productImage = dr["ProductImage"].ToString();
                            int length = int.Parse(dr["Length"].ToString());
                            int wiresNo = int.Parse(dr["WiresNo"].ToString());
                            customerWireSet.WireSets.Add(new AddWireSetModel
                            {
                                ProductID = productId,
                                Price = price,
                                CompanyName = companyName,
                                Model = model,
                                Length = length,
                                WiresNo = wiresNo,
                                ProductImage = productImage
                            }
                            );
                        }
                        return View(customerWireSet);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(int productId, string companyName, string model, decimal price, string productImage)
        {
            string cartJson = HttpContext.Session.Get<string>("_CartItems");
            List<ProductModel> cartItems = JsonConvert.DeserializeObject<List<ProductModel>> (cartJson);
            ProductModel found = cartItems.FirstOrDefault(p => p.ProductID == productId);
            if (found != null)
            {
                found.CartCount++;
            }
            else
            {
                cartItems.Add(new ProductModel { ProductID = productId, CompanyName = companyName, Model = model, Price = price, ProductImage = productImage, CartCount = 1 });
            }
            HttpContext.Session.Set<string>("_CartItems", JsonConvert.SerializeObject(cartItems));
            return Ok();
        }
    }
}
