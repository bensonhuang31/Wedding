using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingCheck.Models;

namespace WeddingCheck.Models
{
    public class TSContext : DbContext
    {
        public TSContext(DbContextOptions<TSContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        //     // Customize the ASP.NET Identity model and override the defaults if needed.
        //     // For example, you can rename the ASP.NET Identity table names and more.
        //     // Add your customizations after calling base.OnModelCreating(builder);
        // }
        //public DbSet<Employee> Employees { get; set; }

        // DB Model
        public virtual DbSet<Wedding> Wedding { get; set; }



        //public DbSet<CheckStatusCheckSPModel> CheckStatusCheckSPModels { get; set; }



    }

    public static class TSContextExtensions
    {
        public static int CountFromSQL(this TSContext context, string sql)
        {
            int count;
            using (var connection = context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    string result = command.ExecuteScalar().ToString();

                    int.TryParse(result, out count);
                }
            }
            return count;
        }
    }
}
