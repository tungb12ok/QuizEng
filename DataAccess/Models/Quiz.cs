using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Histories = new HashSet<History>();
            Questions = new HashSet<Question>();
            Results = new HashSet<Result>();
        }

        public int QuizId { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
