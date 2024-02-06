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
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByIdAsync(string studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task<Student> GetStudentByUserIdAsync(string userId)
        {
           
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == userId); //Where(s => s.Id == userId).SingleOrDefaultAsync();
        }


    }
}
