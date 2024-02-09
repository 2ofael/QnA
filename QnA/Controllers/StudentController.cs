using DataAccessLayer.Repositories;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace QnA.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public StudentController(IQuestionService questionService, IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllQuestionsAskedByStudent()
        {
            List<QuestionViewModel> questionsViewModel = await _questionService.GetQuestionsByCurrStudentAsync();
            return View(questionsViewModel);
        }

        public async Task<IActionResult> QuestionList()
        {
            var questions = await _questionService.GetAllQuestions();
            return View(questions);
        }

        public async Task<IActionResult> AllAnswersForCurrentStudent()
        {
            List<AnswerViewModel> answersViewModel = await _answerService.GetAllAnswersForCurrentUserAsync();
            return View(answersViewModel);
        }
    }
}
