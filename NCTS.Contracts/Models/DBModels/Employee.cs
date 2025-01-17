﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Models.DBModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public string Squad { get; set; } = "NA";
    }
}
