using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Proxy.ProxyClasses
{
    public class ApplicationProxy
    {
        public string name { get; set; }
        public string description { get; set; }
        public string githubRepo { get; set; }
        public string jiraProject { get; set; }
        public string __id { get; set; }
        public DateTime __createdOn { get; set; }
        public DateTime __lastUpdatedOn { get; set; }
    }
}
