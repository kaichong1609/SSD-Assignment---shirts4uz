using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SSD_Assignment___shirts4uz.Models
{
    public class AuditRecord
    {
        [Key]
        public int Audit_ID { get; set; }
        [Display(Name = "Audit Action")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z 0-9\s\,\-\/]*$", ErrorMessage = "Please enter valid string.")]
        public string AuditActionType { get; set; }
        // Could be Login Success /Failure/ Logout, Create, Delete, View, Update
        [Display(Name = "Performed By")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z 0-9\s\,\-\/]*$", ErrorMessage = "Please enter valid string.")]
        public string Username { get; set; }
        //Logged in user performing the action

        [Display(Name = "Date/Time Stamp")]
        [DataType(DataType.DateTime), Required]
        public DateTime DateTimeStamp { get; set; }
        //Time when the event occurred
        [Display(Name = "Shirt Record ID ")]
        [RegularExpression(@"\d{1,30}]*", ErrorMessage = "Please enter valid string."), Required]
        public string KeyShirtFieldID { get; set; }
        //Store the ID of shirt record that is affected
    }
}