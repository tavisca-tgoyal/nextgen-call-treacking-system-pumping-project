using System;
using System.Collections.Generic;
using System.Text;
using NCTS.Contracts.Models.DBModels;
using Serilog;

namespace NCTS.DatabaseServices
{
    public class DatabaseService : IDatabaseServices
    {
        public void InsertApplications(List<Application> applicationList)
        {
            Log.Information("Application DB Model List Received");
            Log.Information(applicationList.ToString());
           
        }

        public void InsertCallData(List<CallData> callDataList)
        {
            throw new NotImplementedException();
        }

        public void InsertCallTrees(List<CallTree> callTreeList)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployeeHours(List<EmployeeHours> employeeHourList)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployees(List<Employee> employeeList)
        {
            Log.Information("employee List received");
            Log.Information(employeeList.ToString());
        }
    }
}
