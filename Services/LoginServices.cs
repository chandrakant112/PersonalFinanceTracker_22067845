using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker.Services
{
    public class LoginServices : ILoginServices
    {
        public async Task<bool> ValidateLoginAsync(User user)
        {
            if (user == null ||
                string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.Currency))
            {
                return false;
            }
            // Simulate API delay
            await Task.Delay(100);

            return user.Username.ToLower() == "chandrakant" &&
                   user.Password == "chandrakant123" &&
                   user.Currency.ToLower() == "usd";
        }
    }
}
