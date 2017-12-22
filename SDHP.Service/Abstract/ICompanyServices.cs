using SDHP.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Abstract
{
   public interface ICompanyServices
    {
        List<CompanyBasicInfo> getAllCompany(ref string errorMessage);
    }
}
