using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }
        public List<Company> Companies { get; set; }
        public int CartCount { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string ProductImage { get; set; }
    }
}
