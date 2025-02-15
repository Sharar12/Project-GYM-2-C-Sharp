using System;
using System.Threading.Tasks;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Services
{
    public class MembershipPlanService : IMembershipPlanService
    {
        private readonly GYMWebContext _context;

        public MembershipPlanService(GYMWebContext context)
        {
            _context = context;
        }

        public async Task<Member> EnrollMemberAsync(Member member, string planTier, decimal fee)
        {
            member.Amount = (int)fee;
            member.JoiningDate = DateTime.UtcNow;
            member.ExpireDate = DateTime.UtcNow.AddMonths(1);
            member.Status = "Active";

            _context.Member.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<bool> RenewPassAsync(int memberId, int months)
        {
            var member = await _context.Member.FindAsync(memberId);
            if (member == null) return false;

            var baseDate = member.ExpireDate > DateTime.UtcNow ? member.ExpireDate : DateTime.UtcNow;
            member.ExpireDate = baseDate.AddMonths(months);
            member.Status = "Active";

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidatePassValidityAsync(int memberId)
        {
            var member = await _context.Member.FindAsync(memberId);
            return member != null && member.ExpireDate >= DateTime.UtcNow && member.Status == "Active";
        }
    }
}
