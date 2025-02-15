using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GYMWeb.Model;

namespace GYMWeb.Services
{
    public interface IMembershipPlanService
    {
        Task<Member> EnrollMemberAsync(Member member, string planTier, decimal fee);
        Task<bool> RenewPassAsync(int memberId, int months);
        Task<bool> ValidatePassValidityAsync(int memberId);
    }
}
