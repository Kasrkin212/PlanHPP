using PlanHPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanHPP.DataServices
{
    public interface IDataWebService
    {
        Task<List<Motor>> GetDataAsync();
        Task ChangeMotor(Motor SelectedMotor);
    }
}
