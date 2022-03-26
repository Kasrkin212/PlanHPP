using PlanHPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanHPP.DataServices
{
    public interface IUserWebService
    {
        Task<T> LoginUserAsync<T>(string url, T user);
        Task SendUser(User user);

    }
}
