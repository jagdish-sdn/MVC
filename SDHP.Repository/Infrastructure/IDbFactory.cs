using SDHP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Repository.Infrastructure
{
  public  interface IDbFactory : IDisposable
    {
        ApplicationContext Init();
    }
}
