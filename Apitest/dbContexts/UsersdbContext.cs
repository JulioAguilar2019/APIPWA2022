using Microsoft.EntityFrameworkCore;
using Apitest.Models;

namespace Apitest.dbContexts

{
    public class UsersdbContext : DbContext
    {

        public DbSet<users> users { get; set; }

        public DbSet<certifications> certifications { get; set; }

        public DbSet<skills> skills { get; set; }

        public DbSet<briefcase> briefcase { get; set; }

        public DbSet<work_experience> work_experience { get; set; }

        public UsersdbContext(DbContextOptions<UsersdbContext> options) : base(options)
        {



        }
    }
}
