using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentInfoContext : DbContext
    {
        public StudentInfoContext() : base("Server=localhost\\SQLEXPRESS;Database=Student_Info_Database;Trusted_Connection=True;") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

      
    }
}
