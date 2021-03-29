using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Models
{
    public class CartModel
    {
        public List<ProductModel> Products { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }
        public int DeliveryFee { get; set; }
        public decimal Total { get; set; }
    }
}
