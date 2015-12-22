using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace EmptyMVCAuthentication01.Models
{
    public class MyDbContext : DbContext
    {
        
        public virtual DbSet<TestModel> TestModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EmptyMVCAuthentication01;integrated security=True;");
        }
    }
}
