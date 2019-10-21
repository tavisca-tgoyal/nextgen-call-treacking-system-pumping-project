using NCTS.Contracts.Models.DBModels;
using NCTS.Services.ApiProxyModelServices;
using NCTS.Services.TranslatorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCTS.Services.Utility
{
    public class CallHour
    {
        private CallTreeServices _callTreeServices;
        private CallTreeTranslator _callTreeTranslator;
        private int _numberOfHours = 15;
        List<EmployeeHours> employeeHours = new List<EmployeeHours>();

        public CallHour()
        {
            _callTreeServices = new CallTreeServices();
            _callTreeTranslator = new CallTreeTranslator();
        }

        public List<EmployeeHours> GetEmployeeHours()
        {
            var callTreeProxyModelList = _callTreeServices.GetProxyObjects().ToList();
            var callTreeList = _callTreeTranslator.ToModel(callTreeProxyModelList);
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday || DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                _numberOfHours = 24;
            List<int> employeeIdList = new List<int>();
            foreach (var callTree in callTreeList)
            {
                employeeIdList.Add(callTree.Level1);
                employeeIdList.Add(callTree.Level2);
                employeeIdList.Add(callTree.Level3);
            }
            List<int> distinctEmployeeIdList = employeeIdList.Distinct().ToList();
            foreach (var employeeId in distinctEmployeeIdList)
            {
                employeeHours.Add(new EmployeeHours()
                {
                    Id = employeeId,
                    Hours = _numberOfHours
                });
            }
            return employeeHours;
        }
    }
}

