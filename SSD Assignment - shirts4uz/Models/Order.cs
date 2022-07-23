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

        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string FullName { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string NameOnCard { get; set; }

        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid email" ), Required]
        public string Email { get; set; }

        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Please enter valid string."), Required]
        public string Address { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string."), Required]
        public string City { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string."), Required]
        public string State { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid string."), Required]
        public int PostalCode { get; set; }

        [RegularExpression(@"\d{16}]*", ErrorMessage = "Please enter valid string."), Required]
        public string CCNum { get; set; }

        [RegularExpression(@"\d{2}]*", ErrorMessage = "Please enter valid number."), Required]
        public int ExpMonth { get; set; }

        [RegularExpression(@"\d{4}]*", ErrorMessage = "Please enter valid year."), Required]
        public int ExpYear { get; set; }

    }
}
