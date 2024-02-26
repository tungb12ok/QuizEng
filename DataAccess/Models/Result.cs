using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public int? StudentId { get; set; }
        public int? QuizId { get; set; }
        public int Score { get; set; }
        public DateTime? TakenAt { get; set; }

        public virtual Quiz? Quiz { get; set; }
        public virtual Student? Student { get; set; }
    }
}
