using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Departments;
using EmploMetrica.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions): base(dbContextOptions)
        {

        }

        public AppDbContext() : base()
        {

        }
        public DbSet<Company> CompanyDbSet { get; set; }
        public DbSet<Department> DepartmentDbSet { get; set; }
        public DbSet<User> UserDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
