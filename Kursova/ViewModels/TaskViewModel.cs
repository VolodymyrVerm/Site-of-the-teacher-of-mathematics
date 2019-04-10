using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Kursova.ViewModels
{
    public class TaskViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public int Score { get; set; }

       // [ForeignKey("TestViewModel")]
        public int ?TestViewModelId { get; set; }

        [JsonIgnore]
        public virtual TestViewModel Test { get; set; }
    }
}
