using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int QuizId { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
    }
}
