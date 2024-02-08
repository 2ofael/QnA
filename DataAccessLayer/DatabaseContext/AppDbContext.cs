using GlobalEntity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DatabaseContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Answers)
                .WithOne(a => a.Teacher)
                .HasForeignKey(a => a.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
      

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Student)
                .HasForeignKey(q => q.StudentId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Question>()
                .HasMany<Answer>(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);




            modelBuilder.Entity<IdentityRole>().HasData(
             new IdentityRole { Id = "1", Name = "Student", NormalizedName = "STUDENT" },
             new IdentityRole { Id = "2", Name = "Teacher", NormalizedName = "TEACHER" },
              new IdentityRole { Id = "3", Name = "Moderator", NormalizedName = "MODERATOR" }
         );

        }
    }
}
