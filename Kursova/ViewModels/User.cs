using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Kursova.Models
{
    public class User:IdentityUser
    {
        public int Score { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
