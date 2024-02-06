using GlobalEntity.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAnswerRepository
    {
        Task AddAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int id);
        Task<List<Answer>> GetAllAnswersAsync();
        Task<Answer> GetAnswerByIdAsync(int id);
        Task UpdateAnswerAsync(Answer answer);
    }
}