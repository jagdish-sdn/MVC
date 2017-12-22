using SDHP.Entities.Professional.FamilyHistories;
using SDHP.Service.Abstract.Professional.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDHP.ViewModel.Professional.FamilyHistories;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using AutoMapper;

namespace SDHP.Service.Service.Professional.FamilyHistories
{
    public class FamilyHistoryService : IFamilyHistoryService
    {
        protected readonly IEntityBaseRepository<FamilyHistory> familyHistoryInfoRepo;
        private readonly IUnitOfWork unitOfWork;

        public FamilyHistoryService(IEntityBaseRepository<FamilyHistory> FamilyHistoryInfoRepo, IUnitOfWork unitOfWork)
        {
            this.familyHistoryInfoRepo = FamilyHistoryInfoRepo;
            this.unitOfWork = unitOfWork;
        }
        public List<FamilyHistory> GetAllFamilyHistory(ref string errorMessage)
        {
            try
            {
                List<FamilyHistory> DBDataCollection = null;

                DBDataCollection = familyHistoryInfoRepo.GetAll().ToList();
                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }

        public FamilyHistory GetFamilyHistoryByID(string ID, ref string errorMessage)
        {
            try
            {
                FamilyHistory data = familyHistoryInfoRepo.Get(x => (x.RecordID.ToString() == ID), ref errorMessage).FirstOrDefault();
                return data;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }

        public FamilyHistory SaveFamilyHistoryDetails(FamilyHistoryViewModel data, ref string errorMessage)
        {
            try
            {
                FamilyHistory DBData = Mapper.Map<FamilyHistoryViewModel, FamilyHistory>(data);
                if (DBData.ID == 0 && DBData.RecordID.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    DBData.CreatedOn = DateTime.UtcNow;
                    DBData.RecordID = Guid.NewGuid();
                    familyHistoryInfoRepo.Add(DBData, ref errorMessage);
                }
                else
                {

                    FamilyHistory savedData = familyHistoryInfoRepo.Get(x => x.RecordID == DBData.RecordID, ref errorMessage).FirstOrDefault();
                    DBData.ID = savedData.ID; DBData.Modifiedon = DateTime.UtcNow;
                    familyHistoryInfoRepo.Update(savedData, DBData, ref errorMessage);
                }
                unitOfWork.Commit();
                return DBData;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }

        public bool? SoftDeleteFamilyHistory(Guid id, ref string errorMessage)
        {
            try
            {
                FamilyHistory DBDataCollection = familyHistoryInfoRepo.Get(x => x.RecordID == id, ref errorMessage).FirstOrDefault();
                if (DBDataCollection == null)
                {
                    errorMessage = "No records found.";
                    return null;
                }
                DBDataCollection.DeletionDate = DateTime.UtcNow;
                DBDataCollection.IsDeleted = true;
                familyHistoryInfoRepo.SoftDelete(DBDataCollection, ref errorMessage);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return false;
        }
    }
}
