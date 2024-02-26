using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModel;

namespace Web.Controllers
{
    public class QuizManagerController : Controller
    {
        private readonly QuizEngContext _context;
        QuestionRepository quesRepo;
        public QuizManagerController(QuizEngContext context)
        {
            _context = context;
            quesRepo = new QuestionRepository(context);
        }

        public IActionResult Index()
        {
            List<QuizViewModel> model = _context.Quizzes
                .Select(x => new QuizViewModel
                {
                    QuizId = x.QuizId,
                    QuizTitle = x.Title
                })
                .ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateQuiz");
        }
        [HttpPost]
        public IActionResult Create(QuizViewModel quiz)
        {
            Quiz q = new Quiz()
            {
                Title = quiz.QuizTitle
            };
            _context.Quizzes.Add(q);
            _context.SaveChanges();

            int quizId = q.QuizId;

            foreach (var item in quiz.Questions)
            {
                Question question = new Question
                {
                    QuizId = quizId,
                    Content = item.QuestionContent,
                    CorrectAnswer = SortString(item.CorrectAnswer)
                };
                quesRepo.createQuestion(question);
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateQuiz(int id)
        {
            Quiz quiz = _context.Quizzes.Find(id);

            if (quiz == null)
            {
                return NotFound();
            }

            List<QuestionViewModel> questions = _context.Questions
                                .Where(q => q.QuizId == id)
                                .Select(q => new QuestionViewModel
                                {
                                    QuestionId = q.QuestionId,
                                    QuestionContent = q.Content,
                                    CorrectAnswer = q.CorrectAnswer
                                })
                                .ToList();

            QuizViewModel viewModel = new QuizViewModel
            {
                QuizId = quiz.QuizId,
                QuizTitle = quiz.Title,
                Questions = questions
            };

            return View(viewModel);
        }

        private string SortString(string input)
        {
            char[] characters = input.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
