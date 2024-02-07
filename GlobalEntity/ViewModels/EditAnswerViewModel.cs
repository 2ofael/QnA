using GlobalEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity.ViewModels
{
    public class EditAnswerViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PostedDate { get; set; }

        public string TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public string QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
