using GlobalEntity.Models;
using GlobalEntity.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IAnswerService
    {
        Task AddAnswerAsync(CreateAnswerViewModel createAnswerViewModel);
        Task DeleteAnswerAsync(string id);
        Task<List<Answer>> GetAllAnswersAsync();
        Task<Answer> GetAnswerByIdAsync(string id);
        Task UpdateAnswerAsync(Answer answer);
    }
}