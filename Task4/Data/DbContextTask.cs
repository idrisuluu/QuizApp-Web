using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task4.Data
{
    public class DbContextTask : DbContext
    {
        //public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=qwe789asd;Server=localhost;Port=5432;Database=QuizDb;Integrated Security=true;Pooling=true;");
        }

        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }

    }
}