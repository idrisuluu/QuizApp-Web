using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task4Project.Models;

namespace Task4.Data
{
    public class DbContextTask : DbContext
    {
        //public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("User ID=ahmet;Password=Qwe789asd;Server=WIN-UU7HLM724TF\\AHMET;Database=QuizDb;TrustServerCertificate=True;Pooling=true;");
        }

        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }

    }
}