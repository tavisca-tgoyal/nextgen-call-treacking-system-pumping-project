using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Interfaces.ApiProxyModel
{
    public interface IApiModelServices<T>
    {
        IEnumerable<T> GetProxyObjects();
    }
}
