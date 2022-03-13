using PlanHPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanHPP.DataServices
{
    public interface IWebService
    {
        Task<List<Motor>> GetDataAsync();
        Task ChaneMotor(Motor SelectedMotor);
    }
}
