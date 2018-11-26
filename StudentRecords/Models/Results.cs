using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

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

        public ICollection<Units> Unit{get; set; }

        public string UnitCode { get; set; }

        public short Semester { get; set; }

        public short Year { get; set; }

        public short Ass1Score { get; set; }

        public short Ass2Score { get; set; }
        public short ExamScore { get; set; }
    }
}
