﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaskViewModel> ListOfQuestion { get; set; }

        public  int CountQuestion { get; set; }

        public TestViewModel()
        {
            ListOfQuestion = new List<TaskViewModel>();
        }
    }
}