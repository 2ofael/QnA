using GlobalEntity.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(Question question);
        Task DeleteQuestionAsync(int id);
        Task<List<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task UpdateQuestionAsync(Question question);
    }
}