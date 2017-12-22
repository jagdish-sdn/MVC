
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDHP.Entities;
using System.Data.Entity;
using SDHP.Entities.Company;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SDHP.Repository
{
   public partial class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("SDHPConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext,
               Migrations.Configuration>("SDHPConnectionString"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyBasicInfo>(); 
        }

        public virtual void Commit()
        {
            using (var dbContextTransaction = this.Database.BeginTransaction())
            {
                try
                {
                    var idx = base.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    dbContextTransaction.Rollback();
                }
            }
        }
    }
}
