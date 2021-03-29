using ArduinoStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Controllers
{
    public class AdminController : Controller
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
            AddBoardModel addBoard = new AddBoardModel();
            addBoard.Companies = new List<Company>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT * FROM Company ORDER BY name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int companyID = int.Parse(dr["CompanyID"].ToString());
                            string name = dr["Name"].ToString();
                            addBoard.Companies.Add(new Company { CompanyID = companyID, Name = name });
                        }
                        return View(addBoard);
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
            AddBreadboardModel addBreadboard = new AddBreadboardModel();
            addBreadboard.Companies = new List<Company>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT * FROM Company ORDER BY name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int companyID = int.Parse(dr["CompanyID"].ToString());
                            string name = dr["Name"].ToString();
                            addBreadboard.Companies.Add(new Company { CompanyID = companyID, Name = name });
                        }
                        return View(addBreadboard);
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
            AddLEDModel addLED = new AddLEDModel();
            addLED.Companies = new List<Company>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT * FROM Company ORDER BY name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int companyID = int.Parse(dr["CompanyID"].ToString());
                            string name = dr["Name"].ToString();
                            addLED.Companies.Add(new Company { CompanyID = companyID, Name = name });
                        }
                        return View(addLED);
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
            AddMotorModel addMotor = new AddMotorModel();
            addMotor.Companies = new List<Company>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT * FROM Company ORDER BY name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int companyID = int.Parse(dr["CompanyID"].ToString());
                            string name = dr["Name"].ToString();
                            addMotor.Companies.Add(new Company { CompanyID = companyID, Name = name });
                        }
                        return View(addMotor);
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
            AddSensorModel addSensor = new AddSensorModel();
            addSensor.Companies = new List<Company>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT * FROM Company ORDER BY name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int companyID = int.Parse(dr["CompanyID"].ToString());
                            string name = dr["Name"].ToString();
                            addSensor.Companies.Add(new Company { CompanyID = companyID, Name = name });
                        }
                        return View(addSensor);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Wireset()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            AddWireSetModel addWireSet = new AddWireSetModel();
            addWireSet.Companies = new List<Company>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT * FROM Company ORDER BY name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int companyID = int.Parse(dr["CompanyID"].ToString());
                            string name = dr["Name"].ToString();
                            addWireSet.Companies.Add(new Company { CompanyID = companyID, Name = name });
                        }
                        return View(addWireSet);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult Delete()
        {
            ViewData["CustomerId"] = HttpContext.Session.Get<int>("_AccountId");
            ViewData["AdminId"] = HttpContext.Session.Get<int>("_AdminId");
            DeleteModel deleteModel = new DeleteModel();
            deleteModel.Products = new List<ProductModel>();
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"SELECT p.*, c.Name FROM Product p JOIN Company c ON p.CompanyId = c.CompanyId WHERE IsDeleted = 0";
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
                            deleteModel.Products.Add(new ProductModel { ProductID = productId, CompanyName = companyName, Price = price, Model = model, ProductImage = productImage });
                        }
                        return View(deleteModel);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult Board(AddBoardModel addBoard)
        {
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"INSERT INTO Product VALUES({addBoard.Price}, {addBoard.CompanyID}, '{addBoard.Model}', 0, '{addBoard.ProductImage}'); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int productID = int.Parse(dr[0].ToString());
                        dr.Close();
                        query = $"INSERT INTO ArduinoBoard VALUES({productID}, {addBoard.SupplyVoltage}, {addBoard.DigitalPins}, {addBoard.AnalogPins}, {addBoard.FlashMemory}, {addBoard.Frequency}); SELECT SCOPE_IDENTITY()";
                        cmd = new SqlCommand(query, conn);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            conn.Close();
                            return RedirectToAction("index", "admin");
                        }
                    }
                    else
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult Breadboard(AddBreadboardModel addBreadboard)
        {
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"INSERT INTO Product VALUES({addBreadboard.Price}, {addBreadboard.CompanyID}, '{addBreadboard.Model}', 0, '{addBreadboard.ProductImage}'); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int productID = int.Parse(dr[0].ToString());
                        dr.Close();
                        query = $"INSERT INTO Breadboard VALUES({productID}, {addBreadboard.Width}, {addBreadboard.Length}, {addBreadboard.TiePoints}); SELECT SCOPE_IDENTITY()";
                        cmd = new SqlCommand(query, conn);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            conn.Close();
                            return RedirectToAction("index", "admin");
                        }
                    }
                    else
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public IActionResult LED(AddLEDModel addLED)
        {
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"INSERT INTO Product VALUES({addLED.Price}, {addLED.CompanyID}, '{addLED.Model}', 0, '{addLED.ProductImage}'); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int productID = int.Parse(dr[0].ToString());
                        dr.Close();
                        query = $"INSERT INTO LED VALUES({productID}, '{addLED.Color}', {addLED.Diameter}, {addLED.Current}); SELECT SCOPE_IDENTITY()";
                        cmd = new SqlCommand(query, conn);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            conn.Close();
                            return RedirectToAction("index", "admin");
                        }
                    }
                    else
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult Motor(AddMotorModel addMotor)
        {
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"INSERT INTO Product VALUES({addMotor.Price}, {addMotor.CompanyID}, '{addMotor.Model}', 0, '{addMotor.ProductImage}'); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int productID = int.Parse(dr[0].ToString());
                        dr.Close();
                        query = $"INSERT INTO Motor VALUES({productID}, {addMotor.Voltage}, {addMotor.Current}, {addMotor.RotationSpeed}); SELECT SCOPE_IDENTITY()";
                        cmd = new SqlCommand(query, conn);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            conn.Close();
                            return RedirectToAction("index", "admin");
                        }
                    }
                    else
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult Sensor(AddSensorModel addSensor)
        {
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"INSERT INTO Product VALUES({addSensor.Price}, {addSensor.CompanyID}, '{addSensor.Model}', 0, '{addSensor.ProductImage}'); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int productID = int.Parse(dr[0].ToString());
                        dr.Close();
                        int digitalPin = addSensor.DigitalPin ? 1 : 0;
                        int analogPin = addSensor.AnalogPin ? 1 : 0;
                        query = $"INSERT INTO Sensor VALUES({productID}, '{addSensor.Type}', {addSensor.Voltage}, {digitalPin}, {analogPin}); SELECT SCOPE_IDENTITY()";
                        cmd = new SqlCommand(query, conn);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            conn.Close();
                            return RedirectToAction("index", "admin");
                        }
                    }
                    else
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult Wireset(AddWireSetModel addWireset)
        {
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"INSERT INTO Product VALUES({addWireset.Price}, {addWireset.CompanyID}, '{addWireset.Model}', 0, '{addWireset.ProductImage}'); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int productID = int.Parse(dr[0].ToString());
                        dr.Close();
                        query = $"INSERT INTO Wireset VALUES({productID}, {addWireset.Length}, {addWireset.WiresNo}); SELECT SCOPE_IDENTITY()";
                        cmd = new SqlCommand(query, conn);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            conn.Close();
                            return RedirectToAction("index", "admin");
                        }
                    }
                    else
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            string connString = @"Data Source=DESKTOP-JM077BN;Initial Catalog=ArduinoStore;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = $"UPDATE Product SET IsDeleted = 1 WHERE ProductId = {productId}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return Ok();
                }
            }
            catch (Exception ex)
            {

            }
            return NotFound();
        }
    }
}
