using NCTS.DatabaseMiddleLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCTS.MiddleLayer.Utility
{
    public interface IEmployeeHour
    {
        Task<List<EmployeeHours>> GetEmployeeHours();
    }
}
