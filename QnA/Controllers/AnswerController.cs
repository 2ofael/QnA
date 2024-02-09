using GlobalEntity.Models;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace QnA.Controllers
{
    [Authorize(Roles = "Teacher, Student")]
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;

      
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> AnswerList()
        {
            List<AnswerViewModel> answersViewModel = await _answerService.GetAllAnswersAsync();
            return View(answersViewModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnswerViewModel answerViewModel = await _answerService.GetAnswerByIdAsync(id);
            if (answerViewModel == null)
            {
                return NotFound();
            }

            return View(answerViewModel);
        }


        [Authorize(Roles ="Student")]
        public IActionResult Create(string  questionId)
        {    
            
            return View(new CreateAnswerViewModel { QuestionId = questionId});
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAnswerViewModel createAnswerViewModel)
        {
            if (ModelState.IsValid)
            {
                await _answerService.AddAnswerAsync(createAnswerViewModel);
                TempData["SuccessMessage"] = "Answer created successfully!";
                return RedirectToAction("Details", "Question", new { id = createAnswerViewModel.QuestionId });
               
            }
            return View(createAnswerViewModel);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnswer(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnswerViewModel answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            return View(answer);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( EditAnswerViewModel editAnswerViewModel)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    await _answerService.UpdateAnswerAsync(editAnswerViewModel);
                    TempData["SuccessMessage"] = "Answer Edited successfully!";
                }
                catch (Exception)
                {
                    if (!AnswerExists(editAnswerViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new {id = editAnswerViewModel.Id});
            }
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnswerViewModel answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            await _answerService.DeleteAnswerAsync(id);
            TempData["SuccessMessage"] = "Answer Deleted successfully!";
            return RedirectToAction("Details", "Question", new {id = answer.QuestionId});
        }



   

        private bool AnswerExists(string id)
        {
            
            return !string.IsNullOrEmpty(id);
        }


  

    }
}
