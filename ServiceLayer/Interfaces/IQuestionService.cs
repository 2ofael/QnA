using GlobalEntity.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(CreateQuestionViewModel createQuestionViewModel);
        Task DeleteQuestionAsync(string id);
        Task<List<QuestionViewModel>> GetAllQuestions();
        Task<QuestionViewModel> GetQuestionByIdAsync(string id);
        Task UpdateQuestionAsync(EditQuestionViewModel editQuestionViewModel);
    }
}