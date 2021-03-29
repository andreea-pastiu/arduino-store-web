using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Models
{
    public class AddLEDModel : ProductModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Color { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Diameter { get; set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Current { get; set; }
    }
}
