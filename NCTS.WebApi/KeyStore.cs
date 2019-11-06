using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCTS.WebApi
{
    public class KeyStore
    {
        public static readonly string ApplicationName = "call_tracking_system";
        public static class Configuration
        {
            public static readonly string RemoteStore = "consul";
            public static readonly string SensitiveDataProvider = "parameterStore";
        }
    }
}