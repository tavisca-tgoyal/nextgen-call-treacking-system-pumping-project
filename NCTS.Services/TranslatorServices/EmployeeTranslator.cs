﻿using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Services.TranslatorServices
{
    public static class EmployeeTranslator 
    {
        public static List<Employee> ToModel(this List<EmployeeProxy> proxyModelList)
        {
            List<Employee> employeeList = new List<Employee>();
            foreach (var employee in proxyModelList)
            {
                employeeList.Add(new Employee()
                {
                    Email = employee.Email,
                    EmployeeCode = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    Id = employee.Id,
                    LastName = employee.LastName,
                    PhoneNumber = employee.PhoneNumber                    
                });
            }
            return employeeList;
        }
    }
}
