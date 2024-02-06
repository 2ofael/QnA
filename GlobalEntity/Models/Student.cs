using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity.Models
{
    public class Student:ApplicationUser
    {
     
        public string InstituteName { get; set; }
        public string IdCardNumber { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
