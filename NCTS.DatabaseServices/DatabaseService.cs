using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;
using NCTS.Contracts.Models.DBModels;
using Serilog;

namespace NCTS.DatabaseServices
{
    public class DatabaseService : IDatabaseServices
    {
        private readonly string _connection;
        private MySqlConnection _sqlConnection;
        public DatabaseService()
        {
            _connection = "SERVER=127.0.0.1;PORT=3306;DATABASE=octs;UID=root;PASSWORD=123456";
            _sqlConnection = new MySqlConnection(_connection);
            _sqlConnection.Open();
        }

        public void InsertApplications(List<Application> applicationList)
        {
            foreach (var application in applicationList)
            {
                var sqlString = "call octs.insert_application('"+ application.ApplicationName+"');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void InsertCallData(List<CallData> callDataList)
        {
            foreach (var callData in callDataList)
            {
                var sqlString = "call octs.insert_call_data('" + callData.CallAction+ "','" + callData.EmployeeCode + "','" + callData.ApplicationName + "','" + callData.Environment + "','" + callData.AlarmName + "','" + callData.TimeStamp + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void InsertCallTrees(List<CallTree> callTreeList)
        {
            foreach (var callTree in callTreeList)
            {
                var sqlString = "call octs.insert_call_tree('" + callTree.ApplicationName + "','" + callTree.Environment + "','" + callTree.Level1Employee + "','" + callTree.Level2Employee + "','" + callTree.Level3Employee + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void InsertEmployeeHours(List<EmployeeHours> employeeHourList)
        {
            foreach (var employeeHour in employeeHourList)
            {
                var sqlString = "call octs.insert_hours_on_support('" + employeeHour.EmployeeId + "','" + employeeHour.Hours + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void InsertEmployees(List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                var sqlString = "call octs.insert_employee('" + employee.Id + "','" + employee.EmployeeCode + "','" + employee.Squad + "','" + employee.FirstName + "','" + employee.LastName + "','" + employee.Email + "','" + employee.PhoneNumber + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
