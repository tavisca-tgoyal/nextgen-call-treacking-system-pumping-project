using NCTS.Contracts.Interfaces.Translator;
using NCTS.Contracts.Models.ApiProxyModels;
using NCTS.Contracts.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Services.TranslatorServices
{
    public class EmployeeTranslator : ITranslator<Employee, EmployeeProxy>
    {
        public List<Employee> ToModel(List<EmployeeProxy> proxyModelList)
        {
            List<Employee> employeeList = new List<Employee>();
            foreach (var employee in proxyModelList)
            {
                employeeList.Add(new Employee()
                {
                    Email = employee.Property1[0].Email,
                    EmployeeId = employee.Property1[0].EmployeeId,
                    FirstName = employee.Property1[0].FirstName,
                    Id = employee.Property1[0].Id,
                    LastName = employee.Property1[0].LastName,
                    PhoneNumber = employee.Property1[0].PhoneNumber
                });
            }
            return employeeList;
        }
    }
}
