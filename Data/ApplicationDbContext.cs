using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ApiService.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<QuestionManagement> Questions { get; set; }
        public DbSet<AnswerManagement> Answers { get; set; }
        public DbSet<QuestionManagement> Questions { get; set; }
    }
}