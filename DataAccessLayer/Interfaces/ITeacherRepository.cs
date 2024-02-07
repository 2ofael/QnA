using GlobalEntity.Models;

namespace DataAccessLayer.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetTeacherByIdAsync(string teacherId);
        Task<Teacher> GetTeacherByUserIdAsync(string userId);
    }
}