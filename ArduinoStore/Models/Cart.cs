using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Models
{
    public class Cart
    {
        public Dictionary<ProductModel, int> CartItems = new Dictionary<ProductModel, int>();
    }
}
