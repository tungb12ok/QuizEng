using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly QuizEngContext _context;

        public QuestionsController(QuizEngContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var quizEngContext = _context.Questions.Include(q => q.Quiz);
            return View(await quizEngContext.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["id"] = id;
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "QuizId", "Title", question.QuizId);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,QuizId,Content,CorrectAnswer,MaxScore")] Question question, int quizId)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("updateQuiz", "QuizManager", new { id = quizId });
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'QuizEngContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool QuestionExists(int id)
        {
          return (_context.Questions?.Any(e => e.QuestionId == id)).GetValueOrDefault();
        }
    }
}
