using SDHP.Service.Abstract;
using SDHP.Service.Abstract.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDHP.Entities.Company;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;

namespace SDHP.Service.Service
{
    public class CompanyServices : ICompanyServices
    {

         protected readonly IEntityBaseRepository<CompanyBasicInfo> _CompanyBasicInfoRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyServices(IEntityBaseRepository<CompanyBasicInfo> CompanyBasicInfoRepo, IUnitOfWork unitOfWork)
        {
            this._CompanyBasicInfoRepo = CompanyBasicInfoRepo;
            this._unitOfWork = unitOfWork;
        }

        public List<CompanyBasicInfo> getAllCompany(ref string errorMessage)
        {
            try
            {
                List<CompanyBasicInfo> DBDataCollection = null;

                DBDataCollection = _CompanyBasicInfoRepo.GetAll().ToList();
                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
    }
    }

