using GlobalEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity.ViewModels
{
    public class EditAnswerViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }



    }

       
}
