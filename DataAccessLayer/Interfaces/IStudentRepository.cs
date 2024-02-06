using GlobalEntity.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(string studentId);
        Task<Student> GetStudentByUserIdAsync(string userId);
    }
}