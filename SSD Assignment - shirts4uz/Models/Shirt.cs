using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Models
{
    public class Shirt
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string Name { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string."), Required]
        public string Color { get; set; }

        public string Size { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z 0-9\s\,\-\/]*$", ErrorMessage = "Please enter valid string."), Required]
        public string Description { get; set; }

        [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "List Date"), DataType(DataType.Date)]
        public DateTime ListDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z 0-9\s\,\-\/]*$", ErrorMessage = "Please enter valid string."), Required]
        public string Category { get; set; }
        //public string Review { get; set; }
        public string PhotoPath { get; set; }
    }
}
