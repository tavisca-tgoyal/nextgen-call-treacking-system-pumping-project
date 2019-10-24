﻿using NCTS.Contracts.Models.ApiProxyModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Interfaces.ApiProxyModel
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeProxy> GetProxyObjects();
    }
}