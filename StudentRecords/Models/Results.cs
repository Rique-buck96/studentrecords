using System.Collections.Generic;

namespace StudentRecords.Models
{
    public class Results
    {
        public string StudentId { get; set; }

        public ICollection<Units> Unit { get; set; }

        public string UnitCode { get; set; }

        public short Semester { get; set; }

        public short Year { get; set; }

        public short Ass1Score { get; set; }

        public short Ass2Score { get; set; }
        public short ExamScore { get; set; }
    }
}
