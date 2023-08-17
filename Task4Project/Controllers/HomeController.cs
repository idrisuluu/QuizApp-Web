using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Task4.Data;
using Task4Project.Models;

namespace Task4.Controllers
{   public class HomeController : Controller
    {
        private readonly DbContextTask _context;
        public HomeController(DbContextTask context)
        {
            _context= context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpGet("Home/QuestionProcessPage", Name = "QuestionProcessPage")]

        public async Task<ActionResult> QuestionProcessPage()
        {
            var model =await  _context.Quiz.Where(x => x.Questions != null && x.Questions != "").ToListAsync();
                return View(model);
        }

        public async Task<ActionResult> Update(Quiz quiz)
        {
            _context.Quiz.Update(quiz);
            await _context.SaveChangesAsync();
            return CreatedAtRoute(nameof(QuestionProcessPage), new {});

        }

        public async Task<ActionResult> Delete(Quiz quiz)
        {
            var aa = _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
            return CreatedAtRoute(nameof(QuestionProcessPage), new { });
        }


        public async Task<ActionResult> AddQuestion(Quiz quiz)
        {
            var aa = await _context.Quiz.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return CreatedAtRoute(nameof(QuestionProcessPage), new { });
        }

        public async Task<IActionResult> ModalPopup()
        {
            return View();
        }




        public async Task<IActionResult> QuestionAnswer()
        {
            var model = await _context.Quiz.Where(x => x.Questions != null && x.Questions != "").ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> QuestionAnswerResponse(List<UserAnswer> userAnswers)
        {
            var isd = userAnswers.Select(x => x.QuizId);
            var question = _context.Quiz.Where(x => isd.Contains(x.Id));
            var totalTrue = 0;
            List<string> wrongAnswer = new();
            foreach (var answer in question) {
                var check = userAnswers.Where(x => x.QuizId == answer.Id && x.Answer == answer.Answer);
                if(check.Any())
                {
                    totalTrue += 1;
                }
                else
                {
                    wrongAnswer.Add($"{answer.Questions} this should be the answer {answer.Answer}");

                }


            }
            var percents = totalTrue * 100;
            var totalPercent = percents == 0 ? 0 : percents / question.Count();

            foreach (var item in userAnswers)
            {
                UserAnswer ass = new UserAnswer()
                {
                    Answer = item.Answer,
                    QuizId = item.QuizId,
                    Name = item.Name
                };
                _context.UserAnswer.Add(ass);
            }

            await _context.SaveChangesAsync();
            return Json(new {SuccessPoint= totalPercent, Wrong= string.Join(" '\n' ", wrongAnswer) });

        }
    }
}