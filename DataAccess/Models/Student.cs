using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Student
    {
        public Student()
        {
            Histories = new HashSet<History>();
            Results = new HashSet<Result>();
        }

        public int StudentId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
