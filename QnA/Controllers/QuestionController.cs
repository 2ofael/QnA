
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Student, Moderator")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [AllowAnonymous]
        public async Task<IActionResult> QuestionList(int pageNumber = 1, int pageSize = 10)
        {
            var paginationModel = await _questionService.GetAllQuestions(pageNumber, pageSize);
            return View(paginationModel);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }


        [Authorize(Roles = "Student")]
        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Student")]
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
                var question = await _questionService.AddQuestionAsync(createQuestionViewModel);
                TempData["SuccessMessage"] = "Question created successfully!";
                return RedirectToAction(nameof(Details), new { id = question.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to create question. Please try again.");
                return View(createQuestionViewModel);
            }
        }



        [Authorize(Roles = "Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuestion(string id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [Authorize(Roles = "Student")]
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
                var question = await _questionService.UpdateQuestionAsync(editQuestionViewModel);
                TempData["SuccessMessage"] = "Question Edited successfully!";
                return RedirectToAction(nameof(Details), new { id = question.Id });
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
                TempData["SuccessMessage"] = "Question Deleted successfully!";
                return RedirectToAction(nameof(QuestionList));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete question. Please try again.");
                return View("Error");
            }
        }


    }
}
