using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using GlobalEntity.Models;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AnswerService(
            IAnswerRepository answerRepository, 
            ITeacherRepository teacherRepository,
            IHttpContextAccessor httpContextAccessor
            )

        {
            _answerRepository = answerRepository;
            _teacherRepository = teacherRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAnswerAsync(CreateAnswerViewModel createAnswerViewModel)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Answer answer = new Answer
            {
                Id = Guid.NewGuid().ToString(),
                Title = createAnswerViewModel.Title,
                Description = createAnswerViewModel.Description,
                PostedDate = DateTime.Now,
                TeacherId = userId,
                QuestionId = createAnswerViewModel.QuestionId


            };
            await _answerRepository.AddAnswerAsync(answer);
        }

        public async Task<List<AnswerViewModel>> GetAllAnswersAsync()
        {   List<AnswerViewModel> answerViewModels = new List<AnswerViewModel>();
            var answers =  await _answerRepository.GetAllAnswersAsync();

            foreach(var answer in answers)
            {
                answerViewModels.Add(new AnswerViewModel
                {
                    Id = answer.Id,
                    Title = answer.Title,
                    Description = answer.Description,
                    PostedDate = answer.PostedDate,
                    QuestionId = answer.QuestionId,


                });
            }
           

            return answerViewModels;
        }

        public async Task<AnswerViewModel> GetAnswerByIdAsync(string id)
        {
            Answer answer = await _answerRepository.GetAnswerByIdAsync(id); 

            AnswerViewModel answerViewModel =  new AnswerViewModel
            {
                Title = answer.Title,
                Description = answer.Description,
                Id = id,
                QuestionId = answer.QuestionId,
                TeacherId = answer.TeacherId,
                Teacher = await _teacherRepository.GetTeacherByIdAsync(answer.TeacherId),
                PostedDate = answer.PostedDate,
            };


            return answerViewModel;

        }

        public async Task<EditAnswerViewModel> UpdateAnswerAsync(EditAnswerViewModel editAnswerViewModel)
        {
            Answer editedAnswer = await _answerRepository.GetAnswerByIdAsync(editAnswerViewModel.Id);
          
            editedAnswer.Title = editAnswerViewModel.Title;
            editedAnswer.Description = editAnswerViewModel.Description;
    
        

            await _answerRepository.UpdateAnswerAsync(editedAnswer);

            return editAnswerViewModel;

        }

        public async Task DeleteAnswerAsync(string id)
        {
            await _answerRepository.DeleteAnswerAsync(id);
        }

        public async Task<List<AnswerViewModel>> GetAllAnsweredByTeacherAsync()
        {

            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (teacherId == null)
            {

                return new List<AnswerViewModel>();
            }

            var answer = await _answerRepository.GetAllAnswersAsync();


            var answers = answer.Where(a=>a.TeacherId == teacherId)
                                             .Select(q => new AnswerViewModel
                                             {
                                                 Id = q.Id,
                                                 Title = q.Title,
                                                 Description = q.Description,
                                                 PostedDate = q.PostedDate
                                             })
                                             .ToList();

            return answers;
        }

    }
}
