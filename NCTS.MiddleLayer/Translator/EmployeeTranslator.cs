using NCTS.MiddleLayer.Model;
using NCTS.Proxy.ProxyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.MiddleLayer.Translator
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
