using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using NCTS.Contracts.Models.DBModels;
using Serilog;

namespace NCTS.DatabaseServices
{
    public class DatabaseService : IDatabaseServices
    {
        private readonly string _connection;
        public DatabaseService()
        {
            _connection = "SERVER=127.0.0.1;PORT=3306;DATABASE=oncalltracking;UID=root;PASSWORD=123456";
        }

        public void InsertApplications(List<Application> applicationList)
        {
            
        }

        public void InsertCallData(List<CallData> callDataList)
        {
        }

        public void InsertCallTrees(List<CallTree> callTreeList)
        {
        }

        public void InsertEmployeeHours(List<EmployeeHours> employeeHourList)
        {
        }

        public void InsertEmployees(List<Employee> employeeList)
        {
        }
    }
}
