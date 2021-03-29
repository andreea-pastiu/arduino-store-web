using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoStore.Models
{
    public class AddSensorModel: ProductModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Type { get; set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Voltage { get; set; }
        public bool DigitalPin { get; set; }
        public bool AnalogPin { get; set; }
    }
}
