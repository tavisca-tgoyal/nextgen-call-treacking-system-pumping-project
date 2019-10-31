using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Proxy.ProxyClasses
{
    public class CallTreeProxy
    {
        public string Application { get; set; }
        public string Environment { get; set; }
        public int Level1 { get; set; }
        public DateTime UTCLastCalledTimestamp { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
    }
}
