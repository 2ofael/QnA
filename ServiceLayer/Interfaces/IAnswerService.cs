using GlobalEntity.Models;
using GlobalEntity.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IAnswerService
    {
        Task AddAnswerAsync(CreateAnswerViewModel createAnswerViewModel);
        Task DeleteAnswerAsync(string id);
        Task<List<AnswerViewModel>> GetAllAnswersAsync();
        Task<AnswerViewModel> GetAnswerByIdAsync(string id);
        Task<EditAnswerViewModel> UpdateAnswerAsync(EditAnswerViewModel editAnswerViewModel);
        Task<List<AnswerViewModel>> GetAllAnsweredByTeacherAsync();
    }
}