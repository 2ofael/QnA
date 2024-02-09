using GlobalEntity.HelperClasses;
using GlobalEntity.Models;
using GlobalEntity.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> AddQuestionAsync(CreateQuestionViewModel createQuestionViewModel);
        Task DeleteQuestionAsync(string id);
        Task<List<QuestionViewModel>> GetAllQuestions();
        Task<QuestionViewModel> GetQuestionByIdAsync(string id);
        Task<Question> UpdateQuestionAsync(EditQuestionViewModel editQuestionViewModel);
        Task<List<QuestionViewModel>> GetNotRepliedQuestionsAsync();

        Task<List<QuestionViewModel>> GetRecentlyAskedByDateAsync();

        Task<List<QuestionViewModel>> GetQuestionsByCurrStudentAsync();

        Task<Pagination<QuestionViewModel>> GetAllQuestions(int pageNumber, int pageSize);
    }
}