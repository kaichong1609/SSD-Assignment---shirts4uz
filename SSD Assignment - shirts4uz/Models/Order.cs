using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Models
{
    public class Order
    {
        public int ID { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string."), Required]
        public string FullName { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string."), Required]
        public string NameOnCard { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int PostalCode { get; set; }
        public int CCNum { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }

    }
}
