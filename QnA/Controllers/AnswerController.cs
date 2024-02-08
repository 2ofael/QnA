using GlobalEntity.Models;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

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
            List<AnswerViewModel> answersViewModel = await _answerService.GetAllAnswersAsync();
            return View(answersViewModel);
        }

  
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
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Answer answer = await _answerService.GetAnswerByIdAsync(id);
        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(answer);
        //}

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
            return RedirectToAction(nameof(Index));
        }



        //    [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    await _answerService.DeleteAnswerAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AnswerExists(string id)
        {
            
            return !string.IsNullOrEmpty(id);
        }


  

    }
}
