using DevFramework.Nort.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.DataAccess.Concrete.EntityFramework.Mappings;
using System.Configuration;

namespace DevFramework.Nort.DataAccess.Concrete.EntityFramework
{
    public class NortContext : DbContext
    {

        #region  Field
        private static string CS
        {
            get { return ConfigurationManager.ConnectionStrings["CSNortContext"].ConnectionString; }
        }
        #endregion

        public NortContext() : base(CS)
        {
            Database.SetInitializer<NortContext>(null);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookStore;Trusted_Connection=true");
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
        }
    }
}
