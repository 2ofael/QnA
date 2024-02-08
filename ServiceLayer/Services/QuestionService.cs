using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using GlobalEntity.Models;
using GlobalEntity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStudentRepository _studentRepository;



        public QuestionService(IQuestionRepository questionRepository, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IStudentRepository studentRepository)
        {
            _questionRepository = questionRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _studentRepository = studentRepository;
        }

        public async Task AddQuestionAsync(CreateQuestionViewModel createQuestionViewModel)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var student = await _studentRepository.GetStudentByUserIdAsync(userId);


            var question = new Question
            {
                Id = Guid.NewGuid().ToString(),
                Title = createQuestionViewModel.Title,
                Description = createQuestionViewModel.Description,
                StudentId = userId,
                PostedDate = DateTime.Now
            };

            await _questionRepository.AddQuestionAsync(question);
        }

        public async Task<List<QuestionViewModel>> GetAllQuestions()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            var questionViewModels = new List<QuestionViewModel>();
            foreach (var question in questions)
            {
                questionViewModels.Add(new QuestionViewModel
                {
                    Id = question.Id,
                    Title = question.Title,
                    Description = question.Description,
                    StudentId = question.StudentId,
                    PostedDate = DateTime.Now


                });
            }
            return questionViewModels;
        }


        public async Task<QuestionViewModel> GetQuestionByIdAsync(string id)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(id);
            var questionViewModel = new QuestionViewModel
            {
                Id = question.Id,
                Title = question.Title,
                Description = question.Description,
                StudentId = question.StudentId,
                PostedDate = DateTime.Now,
                Student = question.Student
            };
            foreach (var ans in question.Answers)
            {
                questionViewModel.Answers.Add(new AnswerViewModel
                {
                    Id = ans.Id,
                    Title = ans.Title,
                    Description = ans.Description,

                    PostedDate = DateTime.Now,

                });
            }
            return questionViewModel;

        }

        public async Task UpdateQuestionAsync(EditQuestionViewModel editQuestionViewModel)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(editQuestionViewModel.Id);
            if (question != null)
            {
                question.Title = editQuestionViewModel.Title;
                question.Description = editQuestionViewModel.Description;
                //  question.StudentId = questionViewModel.StudentId;

                await _questionRepository.UpdateQuestionAsync(question);
            }
        }

        public async Task DeleteQuestionAsync(string id)
        {
            await _questionRepository.DeleteQuestionAsync(id);
        }

        public async Task<List<QuestionViewModel>> GetNotRepliedQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();


            var notRepliedQuestions = questions.Where(q => q.Answers == null || !q.Answers.Any())
                                               .Select(q => new QuestionViewModel
                                               {
                                                   Id = q.Id,
                                                   Title = q.Title,
                                                   Description = q.Description,
                                                   PostedDate = q.PostedDate
                                               })
                                               .ToList();
            return notRepliedQuestions;
        }

        public async Task<List<QuestionViewModel>> GetRecentlyAskedByDateAsync()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            var orderedQuestions = questions.OrderByDescending(q => q.PostedDate)
                                            .Select(q => new QuestionViewModel
                                            {
                                                Id = q.Id,
                                                Title = q.Title,
                                                Description = q.Description,
                                                PostedDate = q.PostedDate
                                            })
                                            .ToList();

            return orderedQuestions;
        }

        public async Task<List<QuestionViewModel>> GetQuestionsByCurrStudentAsync()
        {
            var studentId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (studentId == null)
            {

                return new List<QuestionViewModel>();
            }

            var questions = await _questionRepository.GetAllQuestionsAsync();


            var AskedByCurrStudentQuestions = questions.Where(a => a.StudentId == studentId)
                                             .Select(q => new QuestionViewModel
                                             {
                                                 Id = q.Id,
                                                 Title = q.Title,
                                                 Description = q.Description,
                                                 PostedDate = q.PostedDate
                                             })
                                             .ToList();

            return AskedByCurrStudentQuestions;

        }
    }
}
