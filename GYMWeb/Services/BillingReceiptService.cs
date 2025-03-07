using System;
using System.Threading.Tasks;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Services
{
    public class BillingReceiptService
    {
        private readonly GYMWebContext _context;

        public BillingReceiptService(GYMWebContext context)
        {
            _context = context;
        }

        public async Task<PaymentReceipt> GenerateReceiptAsync(int memberId, decimal amount, string method)
        {
            var receipt = new PaymentReceipt
            {
                MemberId = memberId,
                ReceiptNumber = $"REC-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}",
                AmountPaid = amount,
                Method = method ?? "Cash",
                IssuedAt = DateTime.UtcNow
            };

            _context.Set<PaymentReceipt>().Add(receipt);
            await _context.SaveChangesAsync();
            return receipt;
        }
    }
}
