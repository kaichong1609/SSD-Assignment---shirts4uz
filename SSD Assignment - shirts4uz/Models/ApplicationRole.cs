using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Models
{
    public class ApplicationRole :IdentityRole
    {
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z 0-9\s\,\-\/]*$", ErrorMessage = "Please enter valid string.")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; }
    }
}
