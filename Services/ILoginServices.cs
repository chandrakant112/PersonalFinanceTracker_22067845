using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker.Services
{
    public interface ILoginServices
    {
        Task<bool> ValidateLoginAsync(User user);
    }
}
