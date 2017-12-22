using SDHP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Repository.Infrastructure
{
  public  class DbFactory : Disposable, IDbFactory
    {
        ApplicationContext dbContext;

        public ApplicationContext Init()
        {
            return dbContext ?? (dbContext = new ApplicationContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
    
    
}
