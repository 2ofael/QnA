using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity.Models
{
    public class Teacher:ApplicationUser    
    {
       

        public List<Answer> Answers { get; set; }
    }
}
