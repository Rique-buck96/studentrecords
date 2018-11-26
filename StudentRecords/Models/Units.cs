using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.Models
{
    public class Units
    {
        private string _unitCode;

        public string UnitCode { get; set; }

        public string UnitTitle { get;set; }
        public string UnitCoordinator { get; set; }
        public string UnitOutline { get; set; }
        public Results Results { get;set; }
    }
}
