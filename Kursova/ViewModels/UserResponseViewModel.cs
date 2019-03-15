using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.ViewModels
{
    public class UserResponseViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string QuestionId { get; set; }
        
        public string AnswerUser { get; set; }
    }
}
