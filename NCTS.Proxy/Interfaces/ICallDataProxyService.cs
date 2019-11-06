using NCTS.Proxy.ProxyClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCTS.Proxy.Interfaces
{
    public interface ICallDataProxyService
    {
        Task<List<CallDataProxy>> GetProxyObjects();
    }
}
