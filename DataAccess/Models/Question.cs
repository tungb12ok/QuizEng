using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public int? QuizId { get; set; }
        public string Content { get; set; } = null!;
        public string CorrectAnswer { get; set; } = null!;
        public int MaxScore { get; set; }

        public virtual Quiz? Quiz { get; set; }
    }
}
