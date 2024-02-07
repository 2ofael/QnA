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

        public async Task<List<Answer>> GetAllAnswersAsync()
        {
            return await _answerRepository.GetAllAnswersAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(string id)
        {
            return await _answerRepository.GetAnswerByIdAsync(id);
        }

        public async Task UpdateAnswerAsync(Answer answer)
        {
            await _answerRepository.UpdateAnswerAsync(answer);
        }

        public async Task DeleteAnswerAsync(string id)
        {
            await _answerRepository.DeleteAnswerAsync(id);
        }
    }
}
