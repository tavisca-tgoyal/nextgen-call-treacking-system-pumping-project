using NCTS.DatabaseMiddleLayer.Model;
using System.Collections.Generic;

namespace NCTS.DatabaseMiddleLayer
{
    public interface IDatabaseService
    {
        void InsertEmployees(List<Employee> employeeList);
        void InsertApplications(List<Application> applicationsList);
        void InsertCallData(List<CallData> callDataList);
        void InsertEmployeeHours(List<EmployeeHours> employeeHourList);
        void InsertCallTrees(List<CallTree> callTreeList);
    }
}
