using GlobalEntity.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAnswerRepository
    {
        Task AddAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(string id);
        Task<List<Answer>> GetAllAnswersAsync();
        Task<Answer> GetAnswerByIdAsync(string id);
        Task UpdateAnswerAsync(Answer answer);
    }
}