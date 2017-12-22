using SDHP.Entities.Masters;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract.EntityMasters;
using SDHP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDHP.ViewModel.EntityMaster;
using AutoMapper;

namespace SDHP.Service.Service.EntityMasters
{
    public class CategoryServices : ICategoryServices
    {
        protected readonly IEntityBaseRepository<Category> _categoryInfoRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IEntityBaseRepository<Category> categoryInfoRepo, IUnitOfWork unitOfWork)
        {
            this._categoryInfoRepo = categoryInfoRepo;
            this._unitOfWork = unitOfWork;
        }

        public List<Category> GetAllCategory(ref string errorMessage)
        {
            try
            {
                List<Category> DBDataCollection = null;

                DBDataCollection = _categoryInfoRepo.Get(x => x.IsDeleted == false).ToList();
                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
        public Category SaveCategory(CategoryViewModel data, ref string errorMessage)
        {
            try
            {
                Category DBData = Mapper.Map<CategoryViewModel, Category>(data);

                if (DBData.ID == 0)
                {
                    _categoryInfoRepo.Add(DBData, ref errorMessage);

                }
                else
                {
                    Category SavedData = _categoryInfoRepo.Get(x => x.ID == DBData.ID, ref errorMessage).FirstOrDefault();
                    _categoryInfoRepo.Update(SavedData, DBData, ref errorMessage);
                }
                _unitOfWork.Commit();


                return DBData;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
        public Category GetCategoryByID(long ID, ref string errorMessage)
        {
            try
            {
                Category data = _categoryInfoRepo.Get(x => (x.ID == ID), ref errorMessage).FirstOrDefault();
                return data;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }
        public bool? SoftDeleteCategoryDetails(long id, ref string errorMessage)
        {
            try
            {
                Category DBDataCollection = _categoryInfoRepo.Get(x => x.ID == id, ref errorMessage).FirstOrDefault();
                if (DBDataCollection == null)
                {
                    errorMessage = "No records found.";
                    return null;
                }
                DBDataCollection.DeletionDate = DateTime.UtcNow;
                _categoryInfoRepo.SoftDelete(DBDataCollection, ref errorMessage);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return false;
        }
    }
}
