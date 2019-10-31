using NCTS.Proxy.ProxyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Proxy.Interfaces
{
    public interface ICallDataProxyService
    {
        List<CallDataProxy> GetProxyObjects();
    }
}
