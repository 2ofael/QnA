using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity.ViewModels
{
    public class CreateAnswerViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string QuestionId { get; set; }

    }
}
