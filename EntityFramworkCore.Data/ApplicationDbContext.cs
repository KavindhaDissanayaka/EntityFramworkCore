using EntityFramworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCore.Data
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KAVINDA-MIS; Initial Catalog=EF_HuntingDB;User ID=sa;Password=ksd1234;Trusted_connection=true;TrustServerCertificate=true;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
