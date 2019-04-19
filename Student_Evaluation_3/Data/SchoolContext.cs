using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Evaluation_3.Models;

namespace Student_Evaluation_3.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        // DBcontext constructor

        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        //Tablesets for migrations.
    }
}
