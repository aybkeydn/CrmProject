using System;
using System.ComponentModel.DataAnnotations;

namespace Most_Crm.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PerformedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
