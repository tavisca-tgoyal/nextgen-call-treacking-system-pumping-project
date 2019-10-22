using NCTS.Contracts.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.DatabaseServices
{
    public interface IDatabaseServices
    {
        void InsertEmployees(List<Employee> employeeList);
        void InsertApplications(List<Application> applicationList);
        void InsertCallData(List<CallData> callDataList);
        void InsertEmployeeHours(List<EmployeeHours> employeeHourList);
        void InsertCallTrees(List<CallTree> callTreeList);
    }
}
