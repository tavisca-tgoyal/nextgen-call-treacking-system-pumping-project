using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Models.ApiProxyModels
{
    public class EmployeeProxy
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }
    }
}
