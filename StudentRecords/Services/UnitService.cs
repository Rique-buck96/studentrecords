using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using StudentRecords.Models;

namespace StudentRecords.Services
{
    public class UnitService
    {
        private readonly Units _units;
        public UnitService(Units units)
        {
            _units = units;
        }
        private bool ValidateUnitCode(string unitCode)
        {
            var rx = new Regex(@"^[A-Za-z]{3}[0-9]{4}$",
                RegexOptions.Compiled);

            return rx.IsMatch(unitCode);
        }

        public string SanitiseUnitCode()
        {
            _units.UnitCode = _units.UnitCode.ToUpper();
            _units.UnitCode = _units.UnitCode.Trim();
            return !ValidateUnitCode(_units.UnitCode) ? "" : _units.UnitCode;
        }

        public string SanitiseUnitTitle()
        {
            _units.UnitTitle = Regex.Replace(_units.UnitTitle, @"(^\w)|(\s\w)", m=>m.Value.ToUpper());
            _units.UnitTitle = _units.UnitTitle.Trim();
            return _units.UnitTitle;
        }
    }
}
