using CarkiFelek.Model.DBObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarkiFelek.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }

        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Point> Points { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
