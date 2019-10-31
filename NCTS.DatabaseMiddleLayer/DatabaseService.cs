using MySql.Data.MySqlClient;
using System.Linq;
using NCTS.MiddleLayer.Utility;
using NCTS.Proxy.Interfaces;
using NCTS.MiddleLayer.Translator;
using System;
using Serilog;

namespace NCTS.DatabaseMiddleLayer
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connection;
        private MySqlConnection _sqlConnection;
        public DatabaseService()
        {
            _connection = "SERVER=127.0.0.1;port = 3306;DATABASE=octs;UID=root;PASSWORD=123456";
            _sqlConnection = new MySqlConnection(_connection);
            _sqlConnection.Open();
        }

        public void InsertApplications(IApplicationProxyService applicationProxyService)
        {
            var applicationList = applicationProxyService.GetProxyObjects().ToList().ToModel();
            foreach (var application in applicationList)
            {
                var sqlString = "call octs.insert_application('" + application.ApplicationName + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Information(e.Message.ToString());
                }
            }
        }

        public void InsertCallData(ICallDataProxyService callDataProxyService)
        {
            var callDataList = callDataProxyService.GetProxyObjects().ToList().ToModel();
            foreach (var callData in callDataList)
            {
                var sqlString = "call octs.insert_call_data('" + callData.CallAction + "','" + callData.EmployeeCode + "','" + callData.ApplicationName + "','" + callData.Environment + "','" + callData.AlarmName + "','" + callData.TimeStamp + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Information(e.Message.ToString());
                }
            }
        }

        public async void InsertCallTrees(ICallTreeProxyService callTreeProxyService)
        {
            var callTreeProxies = await callTreeProxyService.GetProxyObjects();
            var callTreeList = callTreeProxies.ToModel();

            foreach (var callTree in callTreeList)
            {
                var sqlString = "call octs.insert_call_tree('" + callTree.ApplicationName + "','" + callTree.Environment + "','" + callTree.Level1Employee + "','" + callTree.Level2Employee + "','" + callTree.Level3Employee + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Information(e.Message.ToString());
                }
            }
        }

        public async void InsertEmployeeHours(IEmployeeHour employeeHour)
        {
            var employeeHourList = await employeeHour.GetEmployeeHours();
            foreach (var empHour in employeeHourList)
            {
                var sqlString = "call octs.insert_hours_on_support('" + empHour.EmployeeId + "','" + empHour.Hours + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Information(e.Message.ToString());
                }
            }
        }

        public async void InsertEmployees(IEmployeProxyService employeProxyService)
        {
            var employeeProxyList = await employeProxyService.GetProxyObjects();
            var employeeList = employeeProxyList.ToModel();
            foreach (var employee in employeeList)
            {
                var sqlString = "call octs.insert_employee('" + employee.Id + "','" + employee.EmployeeCode + "','" + employee.Squad + "','" + employee.FirstName + "','" + employee.LastName + "','" + employee.Email + "','" + employee.PhoneNumber + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Information(e.Message.ToString());
                }
            }
        }
    }
}
