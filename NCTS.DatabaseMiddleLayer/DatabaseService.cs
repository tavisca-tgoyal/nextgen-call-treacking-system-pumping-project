﻿using MySql.Data.MySqlClient;
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
                var sqlString = "call octs.insert_call_data('"  + callData.CallAction + "','" 
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
                    var sqlQuery = "call octs.validate_alarm_name('" + callData.AlarmName + "');";
                    var command = new MySqlCommand(sqlQuery, _sqlConnection);
                    var result = command.ExecuteReader();
                    
                    if(!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call octs.insert_alarm('" + callData.AlarmName + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlQuery = "call octs.validate_application_name('" + callData.ApplicationName + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call octs.insert_application('" + callData.ApplicationName + "');";
                        command = new MySqlCommand(sqlQuery, _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    if (!result.IsClosed)
                        result.Close();
                    sqlQuery = "call octs.validate_employee_code('" + callData.EmployeeCode + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call octs.insert_employee('" + new Random().Next(5000,200000) + "','"
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
                var sqlString = "call octs.insert_call_tree('"  + callTree.ApplicationName + "','" 
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
                    var sqlQuery = "call octs.validate_employee_id('" + callTree.Level1Employee + "');";
                    var command = new MySqlCommand(sqlQuery, _sqlConnection);
                    var result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call octs.insert_employee('" + callTree.Level1Employee + "','"
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
                    sqlQuery = "call octs.validate_employee_id('" + callTree.Level2Employee + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call octs.insert_employee('" + callTree.Level2Employee + "','"
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
                    sqlQuery = "call octs.validate_employee_id('" + callTree.Level3Employee + "');";
                    command = new MySqlCommand(sqlQuery, _sqlConnection);
                    result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        if (!result.IsClosed)
                            result.Close();
                        sqlQuery = "call octs.insert_employee('" + callTree.Level3Employee + "','"
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
                    Log.Information(e.Message.ToString());
                }
            }
        }

        public async void InsertEmployeeHours(IEmployeeHour employeeHour)
        {
            var employeeHourList = await employeeHour.GetEmployeeHours();
            foreach (var empHour in employeeHourList)
            {

                if(empHour.EmployeeId!=0)
                {
                    var sqlString = "call octs.insert_hours_on_support('" + empHour.EmployeeId + "','"
                                                                        + empHour.Hours + "');";
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

        public async void InsertEmployees(IEmployeProxyService employeProxyService)
        {
            var employeeProxyList = await employeProxyService.GetProxyObjects();
            var employeeList = employeeProxyList.ToModel();
            foreach (var employee in employeeList)
            {
                var sqlString = "call octs.insert_employee('"   + employee.Id + "','" 
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
                    Log.Information(e.Message.ToString());
                }
            }
        }
    }
}
