using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Interfaces;
using GlobalEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> GetTeacherByIdAsync(string teacherId)
        {
            return await _context.Teachers.FindAsync(teacherId);
        }

        public async Task<Teacher> GetTeacherByUserIdAsync(string userId)
        {
            return await _context.Teachers.Where(t => t.Id == userId).SingleOrDefaultAsync();
        }

    }
}
