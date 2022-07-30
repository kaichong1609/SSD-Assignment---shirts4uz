using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserEmail { get; set; }
        public string ShirtID { get; set; }

        [Display(Name = "Shirt Name")]
        public string ShirtName { get; set; }
        [Range(1,100)]
        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Price")]
        public decimal TtlPrice { get; set; }


    }
}
