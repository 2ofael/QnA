using GlobalEntity.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(Question question);
        Task DeleteQuestionAsync(string id);
        Task<List<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(string id);
        Task UpdateQuestionAsync(Question question);
    }
}