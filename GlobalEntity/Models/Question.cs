﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEntity.Models
{
    public class Question
    {

  

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PostedDate { get; set; }

        public string StudentId {  get; set; }

        public Student Student { get; set; }

        public List<Answer> Answers { get; set; }




    }
}
