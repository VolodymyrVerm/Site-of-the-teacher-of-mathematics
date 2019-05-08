using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Kursova.Models;

namespace Kursova.ViewModels
{
    public class TestProgress
    {
        public int Id { get; set; }

       // [ForeignKey("TestViewModel")]
        public int? TestId { get; set; }

        public TestViewModel Test { get; set; }

        //[ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        public User User { get; set; }

        //public IdentityUser User { get; set; }
        public DateTime DateTime { get; set; }

        public int Score { get; set; }
    }
}
