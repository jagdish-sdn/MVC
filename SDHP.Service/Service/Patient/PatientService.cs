using AutoMapper;
using Model.Utilities;
using SDHP.Common;
using SDHP.Entities.Patient;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.Patient;
using SDHP.ViewModel.Patient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static SDHP.Common.PublicProcedure;

namespace SDHP.Service.Patient
{
    public class PatientService : IPatientService
    {
        protected readonly IEntityBaseRepository<PatientBasicDetails> _patientBasicInfoRepo;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IEntityBaseRepository<PatientBasicDetails> PatientBasicInfoRepo, IUnitOfWork unitOfWork)
        {
            this._patientBasicInfoRepo = PatientBasicInfoRepo;
            this._unitOfWork = unitOfWork;
        }
        public List<PatientBasicDetails> GetAllPatients(ref string errorMessage)
        {
            try
            {
                List<PatientBasicDetails> DBDataCollection = null;

                DBDataCollection = _patientBasicInfoRepo.GetAll().ToList();
                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
        public PatientBasicDetails SavePatientDetails(PatientViewModel data, ref string errorMessage)
        {
            try
            {
                PatientBasicDetails DBData = Mapper.Map<PatientViewModel, PatientBasicDetails>(data);
                if (DBData.PatientID == "" && DBData.ID == 0)
                {
                    DBData.PatientID = PublicProcedure.GenerateGUID(GUIDExtraction.AlphaNumbers);
                    _patientBasicInfoRepo.Add(DBData, ref errorMessage);
                }
                else
                {
                    PatientBasicDetails SavedData = _patientBasicInfoRepo.Get(x => x.ID == DBData.ID, ref errorMessage).FirstOrDefault();
                    DBData.PatientID = SavedData.PatientID;
                    _patientBasicInfoRepo.Update(SavedData, DBData, ref errorMessage);
                }
                // assume only one file will upload at a time
                string changeFileName = string.Format("{0}_{1}", DBData.PatientID.ToString(), DateTime.UtcNow);
                if (DBData != null && DBData.ProfileImage.Count > 0)
                {
                    foreach (var item in DBData.ProfileImage)
                    {
                        item.ChangedFileName = changeFileName;
                    }
                }
                _unitOfWork.Commit();

                //#region UploadFiles
                //string folder = "Patient";
                ////Create Directory
                //FileUpload.CreateDirectoryInUploads(folder);
                //var httpRequest = HttpContext.Current.Request;
                //foreach (HttpPostedFile file in httpRequest.Files)
                //{
                //    HttpPostedFileBase filebase = new HttpPostedFileWrapper(file);
                //    var listTuple = FileUpload.SaveFileInFolder(filebase, changeFileName, folder);
                //    foreach (var tuple1 in listTuple)
                //    {
                //        if (!tuple1.Item1) // if error
                //        {
                //        }
                //        else
                //        {
                //            errorMessage = "";
                //        }
                //    }
                //}
                //#endregion
                return DBData;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
      
        public PatientBasicDetails GetPatientByID(long ID, ref string errorMessage)
        {
            try
            {
                PatientBasicDetails data = _patientBasicInfoRepo.Get(x => (x.ID == ID), ref errorMessage).FirstOrDefault();
                return data;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }
        public bool? SoftDeletePatientDetails(long id, ref string errorMessage)
        {
            try
            {
                PatientBasicDetails DBDataCollection = _patientBasicInfoRepo.Get(x => x.ID == id, ref errorMessage).FirstOrDefault();
                if (DBDataCollection == null)
                {
                    errorMessage = "No records found.";
                    return null;
                }
                DBDataCollection.DeletionDate = DateTime.UtcNow;
                _patientBasicInfoRepo.SoftDelete(DBDataCollection, ref errorMessage);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return false;
        }

     
    }
}
