using MySql.Data.MySqlClient;
using System.Linq;
using System;
using System.Collections.Generic;
using NCTS.DatabaseMiddleLayer.Model;
using Common.Logging;

namespace NCTS.DatabaseMiddleLayer
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connection;
        private MySqlConnection _sqlConnection;
        private ILogger _logger;

        public DatabaseService(ILogger logger)
        {
            _connection = "SERVER = ncts.cluster-cy6evezde3dw.us-east-1.rds.amazonaws.com; PORT = 3306; DATABASE = ncts; USER Id = ncts_admin; PASSWORD = vfr4VFR$vfr4VFR$";
            _sqlConnection = new MySqlConnection(_connection);
            _sqlConnection.Open();
            _logger = logger;
        }

        public async void InsertApplications(List<Application> applicationList)
        {
            //var applicationList = applicationProxyService.GetProxyObjects().ToList().ToModel();
            foreach (var application in applicationList)
            {
                var sqlString = "call ncts.insert_application('" + application.ApplicationName.ToLower() + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    await _logger.WriteLogAsync(LogHelper.GetTraceLog(e.Message.ToString()));

                }
            }
        }

        public async void InsertCallData(List<CallData> callDataList)
        {
            foreach (var callData in callDataList)
            {
                var sqlString = "call ncts.insert_call_data('"  + callData.CallAction + "','" 
                                                                + callData.EmployeeCode + "','" 
                                                                + callData.ApplicationName + "','" 
                                                                + callData.Environment + "','" 
                                                                + callData.AlarmName + "','" 
                                                                + callData.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss") 
                                                                + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    var sqlQuery = "call ncts.validate_alarm_name('" + callData.AlarmName + "');";
                    var command = new MySqlCommand(sqlQuery, _sqlConnection);
                    var result = command.ExecuteReader();
                    
                    if(!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call ncts.insert_alarm('" + callData.AlarmName + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlQuery = "call ncts.validate_application_name('" + callData.ApplicationName + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call ncts.insert_application('" + callData.ApplicationName + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlQuery = "call ncts.validate_employee_code('" + callData.EmployeeCode + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call ncts.get_minimum_id();";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        result = command.ExecuteReader();
                        var id = result["Id"].ToString();
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call ncts.insert_employee('" + int.Parse(id) + "','"
                                                                + callData.EmployeeCode + "','"
                                                                + "xyz" + "','"
                                                                + "john" + "','"
                                                                + "diesel" + "','"
                                                                + "something@domain.com" + "','"
                                                                + "100"
                                                                + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlCommand.ExecuteNonQuery();
                    await _logger.WriteLogAsync(LogHelper.GetTraceLog(e.Message.ToString()));
                }
            }
        }

        public async void InsertCallTrees(List<CallTree> callTreeList)
        {
            

            foreach (var callTree in callTreeList)
            {
                var sqlString = "call ncts.insert_call_tree('"  + callTree.ApplicationName.ToLower() + "','" 
                                                                + callTree.Environment + "','" 
                                                                + callTree.Level1Employee + "','" 
                                                                + callTree.Level2Employee + "','" 
                                                                + callTree.Level3Employee + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    var sqlQuery = "call ncts.validate_employee_id('" + callTree.Level1Employee + "');";
                    var command = new MySqlCommand(sqlQuery, _sqlConnection);
                    var result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call ncts.insert_employee('" + callTree.Level1Employee + "','"
                                                                + 10009 + "','"
                                                                + "xyz" + "','"
                                                                + "john" + "','"
                                                                + "diesel" + "','"
                                                                + "something@domain.com" + "','"
                                                                + "100"
                                                                + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlQuery = "call ncts.validate_employee_id('" + callTree.Level2Employee + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call ncts.insert_employee('" + callTree.Level2Employee + "','"
                                                                + 10010 + "','"
                                                                + "xyz" + "','"
                                                                + "john" + "','"
                                                                + "diesel" + "','"
                                                                + "something@domain.com" + "','"
                                                                + "100"
                                                                + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlQuery = "call ncts.validate_employee_id('" + callTree.Level3Employee + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call ncts.insert_employee('" + callTree.Level3Employee + "','"
                                                                + 10011 + "','"
                                                                + "xyz" + "','"
                                                                + "john" + "','"
                                                                + "diesel" + "','"
                                                                + "something@domain.com" + "','"
                                                                + "100"
                                                                + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlCommand.ExecuteNonQuery();
                    await _logger.WriteLogAsync(LogHelper.GetTraceLog(e.Message.ToString()));
                }
            }
        }

        public async void InsertEmployeeHours(List<EmployeeHours> employeeHourList)
        {
            //var employeeHourList = await employeeHour.GetEmployeeHours();
            foreach (var empHour in employeeHourList)
            {

                if(empHour.EmployeeId!=0)
                {
                    var sqlString = "call ncts.insert_hours_on_support('" + empHour.EmployeeId + "','"
                                                                        + empHour.Hours + "');";
                    var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        await _logger.WriteLogAsync(LogHelper.GetTraceLog(e.Message.ToString()));
                    }
                }
            }
        }

        public async void InsertEmployees(List<Employee> employeeList)
        {
            //var employeeProxyList = await employeProxyService.GetProxyObjects();
            //var employeeList = employeeProxyList.ToModel();
            foreach (var employee in employeeList)
            {
                var sqlString = "call ncts.insert_employee('"   + employee.Id + "','" 
                                                                + employee.EmployeeCode + "','" 
                                                                + employee.Squad + "','" 
                                                                + employee.FirstName + "','" 
                                                                + employee.LastName + "','" 
                                                                + employee.Email + "','" 
                                                                + employee.PhoneNumber 
                                                                + "');";
                var sqlCommand = new MySqlCommand(sqlString, _sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    await _logger.WriteLogAsync(LogHelper.GetTraceLog(e.Message.ToString()));
                }
            }
        }
    }
}
