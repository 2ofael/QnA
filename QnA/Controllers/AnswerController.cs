using GlobalEntity.Models;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace QnA.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> AnswerList()
        {
            List<Answer> answers = await _answerService.GetAllAnswersAsync();
            return View(answers);
        }

  
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

    
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
                return RedirectToAction(nameof(Index));
            }
            return View(createAnswerViewModel);
        }

 
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            return View(answer);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Text")] Answer answer)
        {
            if (id != answer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _answerService.UpdateAnswerAsync(answer);
                }
                catch (Exception)
                {
                    if (!AnswerExists(answer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(answer);
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _answerService.DeleteAnswerAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(string id)
        {
            
            return !string.IsNullOrEmpty(id);
        }





    }
}
