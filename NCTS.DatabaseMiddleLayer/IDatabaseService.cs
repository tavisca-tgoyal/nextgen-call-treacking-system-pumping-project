using NCTS.MiddleLayer.Model;
using NCTS.MiddleLayer.Utility;
using NCTS.Proxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.DatabaseMiddleLayer
{
    public interface IDatabaseService
    {
        void InsertEmployees(IEmployeProxyService employeProxyService);
        void InsertApplications(IApplicationProxyService applicationProxyService);
        void InsertCallData(ICallDataProxyService callDataProxyService);
        void InsertEmployeeHours(IEmployeeHour employeeHour);
        void InsertCallTrees(ICallTreeProxyService callTreeProxyService);
    }
}
