﻿using NCTS.Contracts.Models.ApiProxyModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.Contracts.Interfaces.ApiProxyModel
{
    public interface IApplicationServices
    {
        List<AppProxy> GetProxyObjects();
    }
}
