using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kursova.ViewModels
{
    public class TestProgress
    {
        public int Id { get; set; }

       // [ForeignKey("TestViewModel")]
        public int TestId { get; set; }

        public TestViewModel Test { get; set; }

        public bool Completed { get; set; }

        //[ForeignKey("AspNetUsers")]
        public string IdentityUserId { get; set; }

        //public IdentityUser User { get; set; }

    }
}
