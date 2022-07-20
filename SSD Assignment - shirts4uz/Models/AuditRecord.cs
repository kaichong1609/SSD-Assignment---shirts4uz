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
        public string AuditActionType { get; set; }
        // Could be Login Success /Failure/ Logout, Create, Delete, View, Update
        [Display(Name = "Performed By")]
        public string Username { get; set; }
        //Logged in user performing the action

        [Display(Name = "Date/Time Stamp")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeStamp { get; set; }
        //Time when the event occurred
        [Display(Name = "Shirt Record ID ")]
        public int KeyShirtFieldID { get; set; }
        //Store the ID of shirt record that is affected
    }
}