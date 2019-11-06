using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.DatabaseMiddleLayer.Model
{
    public class CallData
    {
        public string AlarmName { get; set; }
        public string CallAction { get; set; }
        public string EmployeeCode { get; set; }
        public string ApplicationName { get; set; }
        public string Environment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
