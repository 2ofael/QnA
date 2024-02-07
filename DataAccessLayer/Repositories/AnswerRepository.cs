using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Interfaces;
using GlobalEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Repositories.AnswerRepository;

namespace DataAccessLayer.Repositories
{

    public class AnswerRepository : IAnswerRepository
        {
            private readonly AppDbContext _context;

            public AnswerRepository(AppDbContext context)
            {
                _context = context;
            }


            public async Task AddAnswerAsync(Answer answer)
            {
                _context.Answers.Add(answer);
                await _context.SaveChangesAsync();
            }


            public async Task<List<Answer>> GetAllAnswersAsync()
            {
                return await _context.Answers.ToListAsync();
            }


            public async Task<Answer> GetAnswerByIdAsync(string id)
            {
            //  var answers = _context.Answers.Include(a=>a.Teacher).Where(a => a.Id == id).FirstOrDefault();

            // return answers;
     
            return await _context.Answers.FirstOrDefaultAsync(a=>a.Id == id);
            }


            public async Task UpdateAnswerAsync(Answer answer)
            {
                _context.Entry(answer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }


            public async Task DeleteAnswerAsync(string id)
            {
                var answer = await _context.Answers.FindAsync(id);
                if (answer != null)
                {
                    _context.Answers.Remove(answer);
                    await _context.SaveChangesAsync();
                }
            }
        }



    
}
