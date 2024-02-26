using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class QuestionRepository
    {
        private readonly QuizEngContext _quizEngContext;

        public QuestionRepository(QuizEngContext quizEngContext)
        {
            _quizEngContext = quizEngContext;
        }

        public List<Question> GetAllQuestions()
        {
            return _quizEngContext.Questions.ToList();
        }
        public Question GetQuestionById(int id)
        {
            return _quizEngContext.Questions.FirstOrDefault(x => x.QuestionId == id);
        }

        public bool createQuestion(Question question)
        {
            try
            {
                _quizEngContext.Questions.Add(question);
                _quizEngContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool updateQuestion(Question question)
        {
            try
            {
                Question update = _quizEngContext.Questions.FirstOrDefault(x => x.QuestionId == question.QuestionId);
                if (update != null)
                {
                    update.Content = question.Content;
                    update.CorrectAnswer = question.CorrectAnswer;
                    update.MaxScore = question.CorrectAnswer.Length;
                }
                _quizEngContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
