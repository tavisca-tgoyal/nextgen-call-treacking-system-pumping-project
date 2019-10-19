using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Models.DBModels
{
    public class CallTree
    {
        public string Application { get; set; }
        public string Environment { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
    }
}
