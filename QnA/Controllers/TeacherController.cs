using GlobalEntity.Models;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace QnA.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly IQuestionService _questionService;

        private readonly IAnswerService _answerService;

        public TeacherController(IQuestionService questionService, IAnswerService answerService) {
            
            _questionService = questionService;
            _answerService = answerService;


        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NotRepliedQuestions()
        {
            var notRepliedQuestions = await _questionService.GetNotRepliedQuestionsAsync();
            return View(notRepliedQuestions);
        }

        public async Task<IActionResult> QuestionList()
        {
            var questions = await _questionService.GetAllQuestions();
            return View(questions);
        }

        [HttpGet]
        public async Task<IActionResult> AllAnsweredByTeacher()
        {
            var answeres = await _answerService.GetAllAnsweredByTeacherAsync();
            return View(answeres);
        }
        public async Task<IActionResult> RecentlyAskedByDate()
        {
            var questionsViewModel = await _questionService.GetRecentlyAskedByDateAsync();
            return View(questionsViewModel);
        }

      

      



      
    }
}
