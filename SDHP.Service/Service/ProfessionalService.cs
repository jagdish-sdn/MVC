using AutoMapper;
using SDHP.Common;
using SDHP.Entities.Patient;
using SDHP.Entities.Professional;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.ViewModel.Professional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static SDHP.Common.PublicProcedure;

namespace SDHP.Service.Service
{
   public class ProfessionalService:IProfessionalService
    {
        protected readonly IEntityBaseRepository<ProfessionalBuisnessControl> _professionalBuisnessControlRepo;
        protected readonly IEntityBaseRepository<PatientBasicDetails> _patientBasicInfoRepo;
        protected readonly IEntityBaseRepository<ProfessionalBasicDetails> _professionalBasicDetailsRepo;


        private readonly IUnitOfWork _unitOfWork;

        public ProfessionalService(IEntityBaseRepository<ProfessionalBuisnessControl> ProfessionalBuisnessControlRepo,
            IEntityBaseRepository<ProfessionalBasicDetails> ProfessionalBasicDetailsRepo,
            IEntityBaseRepository<PatientBasicDetails> PatientBasicInfoRepo, IUnitOfWork unitOfWork)
        {
            this._patientBasicInfoRepo = PatientBasicInfoRepo;
            this._professionalBuisnessControlRepo = ProfessionalBuisnessControlRepo;

            this._professionalBasicDetailsRepo = ProfessionalBasicDetailsRepo;
            this._unitOfWork = unitOfWork;
        }


        


        /// <summary>
        /// Created By Saurabh wanjari
        /// Get All Prfessional data
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<ProfessionalBasicDetails> getProfessionalList(ref string errorMessage)
        {
            try
            {
                List<ProfessionalBasicDetails> DBDataCollection = null;

            //  DBDataCollection = _professionalBasicDetailsRepo.Get(x => x.IsDeleted == false || x.IsDeleted == null).ToList();
                DBDataCollection = _professionalBasicDetailsRepo.Get(x => x.IsDeleted == false || x.IsDeleted == null).ToList();

                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }

        /// <summary>
        /// Created By Saurabh wanjari
        /// Post All Prfessional data
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public ProfessionalBasicDetails SaveProfessionalBasicDetails(ProfessionalViewModel data, ref string errorMessage)
        {
            try
            {
                ProfessionalBasicDetails DBData = Mapper.Map<ProfessionalViewModel, ProfessionalBasicDetails>(data);
                

                if (DBData.ProfessionalID == "" && DBData.ID == 0)
                {
                    DBData.ProfessionalID = PublicProcedure.GenerateGUID(GUIDExtraction.AlphaNumbers);
                    DBData.IsDeleted = false;
                    _professionalBasicDetailsRepo.Add(DBData, ref errorMessage);
                }
                else
                {
                    ProfessionalBasicDetails SavedData = _professionalBasicDetailsRepo.Get(x => x.ID == DBData.ID, ref errorMessage).FirstOrDefault();
                    DBData.ProfessionalID = SavedData.ProfessionalID;
                    DBData.IsDeleted = false;
                    _professionalBasicDetailsRepo.Update(SavedData, DBData, ref errorMessage);
                }
                //if (DBData.ProfessionalID != null)
                //{
                //    var ProfessionalData = _professionalBasicDetailsRepo.Get(x => x.ProfessionalID == DBData.ProfessionalID).ToList();
                //    if (ProfessionalData != null && DBData.ID == 0)
                //    {
                //        _professionalBasicDetailsRepo.Add(DBData, ref errorMessage);
                //    }
                //    else
                //    {
                //        ProfessionalBasicDetails SavedData = _professionalBasicDetailsRepo.Get(x => x.ID == DBData.ID, ref errorMessage).FirstOrDefault();
                //        _professionalBasicDetailsRepo.Update(SavedData, DBData, ref errorMessage);
                //    }
                //}
                //else
                //{
                //    return null;
                //}

                _unitOfWork.Commit();
                return DBData;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }


        /// <summary>
        /// Created By Saurabh wanjari
        /// get by id Prfessional data
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public ProfessionalBasicDetails GetProfessionalBasicDetailByID(long ID, ref string errorMessage)
        {
            try
            {
                ProfessionalBasicDetails data = _professionalBasicDetailsRepo.Get(x => (x.ID == ID), ref errorMessage).FirstOrDefault();
                return data;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }



        /// <summary>
        /// Created By Saurabh wanjari
        /// soft delete Prfessional data
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
     

         public bool? SoftDeleteProfessionalBasicDetails(long id, ref string errorMessage)
        {
            try
            {
                
                ProfessionalBasicDetails DBDataCollection = _professionalBasicDetailsRepo.Get(x => x.ID == id, ref errorMessage).FirstOrDefault();
                if (DBDataCollection == null)
                {
                    errorMessage = "No records found.";
                    return null;
                }
                DBDataCollection.DeletionDate = DateTime.UtcNow;
                DBDataCollection.IsDeleted = true;
                _professionalBasicDetailsRepo.SoftDelete(DBDataCollection, ref errorMessage);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return false;
        }

        /// <summary>
        /// Created By Priyanka Chandak
        /// Get All Buisness Controll Data
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public List<ProfessionalBuisnessControl> getProfessionalBuisnessControl(ref string errorMessage)
        {
            try
            {
                List<ProfessionalBuisnessControl> DBDataCollection = null;

                DBDataCollection = _professionalBuisnessControlRepo.Get(x => x.IsDeleted == false || x.IsDeleted == null).ToList();
                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
       public ProfessionalBuisnessControl SaveBuisnessControl(ProfessionalBuisnessControlViewModel data, ref string errorMessage)
        {
            try
            {
                ProfessionalBuisnessControl DBData = Mapper.Map<ProfessionalBuisnessControlViewModel, ProfessionalBuisnessControl>(data);
             //   DBData.AppointmentDate = DateTime.UtcNow;
                if (DBData.PatientID != null)
                {
                    var PatientData = _patientBasicInfoRepo.Get(x => x.PatientID == DBData.PatientID).ToList();
                    if (PatientData != null && DBData.ID == 0)
                    {
                        _professionalBuisnessControlRepo.Add(DBData, ref errorMessage);
                    }
                    else
                    {
                        ProfessionalBuisnessControl SavedData = _professionalBuisnessControlRepo.Get(x => x.ID == DBData.ID, ref errorMessage).FirstOrDefault();
                        _professionalBuisnessControlRepo.Update(SavedData, DBData, ref errorMessage);
                    }                   
                }
                else {
                    return null;
                }        
                
                _unitOfWork.Commit();
                return DBData;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
        public ProfessionalBuisnessControl GetProfessionalByID(long ID, ref string errorMessage)
        {
            try
            {               
                ProfessionalBuisnessControl data = _professionalBuisnessControlRepo.Get(x => (x.ID == ID), ref errorMessage).FirstOrDefault();
                return data;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }
        //public bool? SoftDeleteProfessionalDetails(long id, ref string errorMessage)
        
        public bool? SoftDeleteProfessionalDetails(long id, ref string errorMessage)
        {

            try
            {
                ProfessionalBuisnessControl DBDataCollection = _professionalBuisnessControlRepo.Get(x => x.ID == id, ref errorMessage).FirstOrDefault();
               

                if (DBDataCollection == null)
                {
                    errorMessage = "No records found.";
                    return null;
                }
                DBDataCollection.DeletionDate = DateTime.UtcNow;
                _professionalBuisnessControlRepo.SoftDelete(DBDataCollection, ref errorMessage);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return false;
        }
        public bool? RemoveProfessionalBuisnessControl(long ids, ref string errorMessage)
        {
            try
            {
                List<PatientBasicDetails> DBDataCollection = _patientBasicInfoRepo.Get(x => x.ID == ids, ref errorMessage).ToList();
                if (DBDataCollection == null || DBDataCollection.Count == 0)
                {
                    errorMessage = "No records found.";
                    return null;
                }
                foreach (PatientBasicDetails DBData in DBDataCollection)
                {
                    _patientBasicInfoRepo.SoftDelete(DBData, ref errorMessage);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return false;
        }
    }

    }

