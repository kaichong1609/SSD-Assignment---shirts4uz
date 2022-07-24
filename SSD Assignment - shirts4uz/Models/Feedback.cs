using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Models
{
    public class Feedback
    {
        public int ID { get; set; }

        [StringLength(60, ErrorMessage = "Please enter valid string.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string FullName { get; set; }

        [StringLength(300, MinimumLength = 1, ErrorMessage = "Please enter valid string.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string ShirtID { get; set; }
    }
}
