using NCTS.MiddleLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.MiddleLayer.Utility
{
    public interface IEmployeeHour
    {
        Task<List<EmployeeHours>> GetEmployeeHours();
    }
}
