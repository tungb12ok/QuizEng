using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using Web.ViewModel;
using DataAccess.Tool;
namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuizEngContext _context;

        public HomeController(ILogger<HomeController> logger, QuizEngContext context)
        {
            _logger = logger;
            _context = context;
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
        public IActionResult Quiz(int id)
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
        [HttpPost]
        public IActionResult SubmitAnswers(IFormCollection form)
        {
            int count = 0;
            int total = 0;
            List<Question> submittedAnswers = new List<Question>();
            foreach (var key in form.Keys)
            {
                if (key.StartsWith("answer_"))
                {
                    int questionId = int.Parse(key.Replace("answer_", ""));
                    string selectedOption = form[key];
                    Question q = _context.Questions.FirstOrDefault(x => x.QuestionId == questionId);
                    if (CheckingQuestion.checkQuestion(q, selectedOption))
                    {
                        count++;
                    }
                    total++;
                }
            }


            return RedirectToAction("Result", new { score = count, total = total });
        }

        public IActionResult Result(int score, int total)
        {
            ViewData["Title"] = "Quiz Result";

            ViewData["Total"] = total;
            ViewData["Score"] = score;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
