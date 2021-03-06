﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kursova.ViewModels;

namespace Kursova.Models
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
     
        

        public DbSet<TaskViewModel> Tasks { get; set; }

        public DbSet<UserResponseViewModel> Answers { get; set; }

        public DbSet<TestViewModel> Tests { get; set; }

        public DbSet<TestProgress> TestsProgress { get; set; }
    }
}
