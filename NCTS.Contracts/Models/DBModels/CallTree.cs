using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Models.DBModels
{
    public class CallTree
    {
        public string ApplicationName { get; set; }
        public string Environment { get; set; }
        public int Level1Employee { get; set; }
        public int Level2Employee { get; set; }
        public int Level3Employee { get; set; }
    }
}
