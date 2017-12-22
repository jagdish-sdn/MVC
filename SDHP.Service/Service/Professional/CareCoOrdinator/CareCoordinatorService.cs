using SDHP.Entities.Professional.CareCoOrdinator;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract.Professional.CareCoOrdinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDHP.ViewModel.Professional.CareCoOrdinator;
using SDHP.Repository;
using AutoMapper;

namespace SDHP.Service.Service.Professional.CareCoOrdinator
{
    public class CareCoordinatorService: ICareCoordinatorService
    {
        protected readonly IEntityBaseRepository<CareCoordinator> careCoordinatorInfoRepo;
        private readonly IUnitOfWork unitOfWork;
        public CareCoordinatorService(IEntityBaseRepository<CareCoordinator> CareCoordinatorInfoRepo, IUnitOfWork unitOfWork)
        {
            this.careCoordinatorInfoRepo = CareCoordinatorInfoRepo;
            this.unitOfWork = unitOfWork;
        }

        public List<CareCoordinator> GetAllCareCoordinator(ref string errorMessage)
        {
            try
            {
                List<CareCoordinator> DBDataCollection = null;

                DBDataCollection = careCoordinatorInfoRepo.GetAll().ToList();
                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }

        public CareCoordinator GetCareCoordinatorByID(string ID, ref string errorMessage)
        {
            try
            {
                CareCoordinator data = careCoordinatorInfoRepo.Get(x => (x.RecordID.ToString() == ID), ref errorMessage).FirstOrDefault();
                return data;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }

        public CareCoordinator SaveCareCoordinatorDetails(CareCoordinatorViewModel data, ref string errorMessage)
        {
            try
            {
                CareCoordinator DBData = Mapper.Map<CareCoordinatorViewModel, CareCoordinator>(data);
                if (DBData.ID == 0 && DBData.RecordID.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    DBData.CreatedOn = DateTime.UtcNow;
                    DBData.RecordID = Guid.NewGuid();
                    careCoordinatorInfoRepo.Add(DBData, ref errorMessage);
                }
                else
                {
                    CareCoordinator savedData = careCoordinatorInfoRepo.Get(x => x.RecordID == DBData.RecordID, ref errorMessage).FirstOrDefault();
                    DBData.ID = savedData.ID; DBData.Modifiedon = DateTime.UtcNow;
                    careCoordinatorInfoRepo.Update(savedData, DBData, ref errorMessage);
                }
                unitOfWork.Commit();
                return DBData;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }

        public bool? SoftDeleteCareCoordinator(Guid id, ref string errorMessage)
        {
            try
            {
                CareCoordinator DBDataCollection = careCoordinatorInfoRepo.Get(x => x.RecordID == id, ref errorMessage).FirstOrDefault();
                if (DBDataCollection == null)
                {
                    errorMessage = "No records found.";
                    return null;
                }
                DBDataCollection.DeletionDate = DateTime.UtcNow;
                DBDataCollection.IsDeleted = true;
                careCoordinatorInfoRepo.SoftDelete(DBDataCollection, ref errorMessage);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return false;
        }
    }
}
