using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Models
{
    public class Delivery
    {
        public int ID { get; set; }

        [StringLength(300, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z 0-9\s\,\-\/\#]*$", ErrorMessage = "Please enter valid string.")]
        public string Address { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string City { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string State { get; set; }

        [Display(Name = "Postal Code")]
        [RegularExpression(@"\d{1,30}]*", ErrorMessage = "Please enter valid string."), Required]
        public int PostalCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Display(Name = "Shirt Name")]
        public string ShirtName { get; set; }

        public string ShirtID { get; set; }

        public string UserEmail { get; set; }

    }
}
