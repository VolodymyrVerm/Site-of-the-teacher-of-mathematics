using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kursova.ViewModels
{
    public class UserResponseViewModel
    {
        public int Id { get; set; }

        //[ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("TaskViewModel")]
        public int? TaskViewModelId { get; set; }
        
        public TaskViewModel Task { get; set; }

        public string AnswerUser { get; set; }

    }
}
