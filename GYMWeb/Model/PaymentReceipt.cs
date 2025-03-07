using System;
using System.ComponentModel.DataAnnotations;

namespace GYMWeb.Model
{
    public class PaymentReceipt
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal AmountPaid { get; set; }
        public string Method { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}
