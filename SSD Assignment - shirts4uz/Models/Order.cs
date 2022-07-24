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

        [StringLength(320, MinimumLength = 5, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid email" )]
        public string Email { get; set; }

        [StringLength(300, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Please enter valid string.")]
        public string Address { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string City { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string State { get; set; }

        [RegularExpression(@"\d{1,30}]*", ErrorMessage = "Please enter valid string."), Required]
        public int PostalCode { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression(@"\d{16}]*", ErrorMessage = "Please enter valid string.")]
        public string CCNum { get; set; }

        [Range(1,12, ErrorMessage = "Please enter valid number."), RegularExpression(@"\d{1,2}]*", ErrorMessage = "Please enter valid number."), Required]
        public int ExpMonth { get; set; }

        [Range(2022,3000, ErrorMessage = "Please enter valid year"), RegularExpression(@"\d{4}]*", ErrorMessage = "Please enter valid year."), Required]
        public int ExpYear { get; set; }

        public string ShirtID { get; set; }

    }
}
