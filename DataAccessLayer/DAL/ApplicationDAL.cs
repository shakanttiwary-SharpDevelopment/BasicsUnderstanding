using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DAL
{
    public class ApplicationDAL : DbContext
    {
        public ApplicationDAL(DbContextOptions<ApplicationDAL> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
