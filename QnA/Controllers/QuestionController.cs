using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace QnA.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IActionResult Index()
        {
     
            return View();
        }

        public async Task<IActionResult> QuestionList()
        {
            var questions = await _questionService.GetAllQuestions();
            return View(questions);
        }

        public async Task<IActionResult> Details(string id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuestionViewModel createQuestionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createQuestionViewModel);
            }

            try
            {
                await _questionService.AddQuestionAsync(createQuestionViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to create question. Please try again.");
                return View(createQuestionViewModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditQuestionViewModel editQuestionViewModel)
        {
            if (id != editQuestionViewModel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(editQuestionViewModel);
            }

            try
            {
                await _questionService.UpdateQuestionAsync(editQuestionViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to update question. Please try again.");
                return View(editQuestionViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _questionService.DeleteQuestionAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete question. Please try again.");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
