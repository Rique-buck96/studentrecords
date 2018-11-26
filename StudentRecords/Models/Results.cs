using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentRecords.Models
{
    public class Results
    {
        private string _studentId;
        private string _unitCode;

        public string StudentId
        {
            get => _studentId;
            set => _studentId = value.Length == 8 ? value : throw new ArgumentException("value");
        }

        public virtual ICollection<Units> Unit{get; set; }

        public string UnitCode
        {
            get => _unitCode;
            set => _unitCode = value.Length == 7 ? value : throw new ArgumentException("value");
        }

        public short Semester { get; set; }

        public short Year { get; set; }

        public short Ass1Score { get; set; }

        public short Ass2Score { get; set; }
        public short ExamScore { get; set; }
    }
}
