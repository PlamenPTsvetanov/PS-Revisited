using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class UserContext : DbContext
    {

        public UserContext() : base("Server=localhost\\SQLEXPRESS;Database=Student_Info_Database;Trusted_Connection=True;") { }
        public DbSet<User> Users { get; set; }
    }
}
