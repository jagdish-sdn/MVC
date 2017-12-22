using AutoMapper;
using Microsoft.AspNet.Identity;
using SDHP.Common;
using SDHP.Entities.Company;
using SDHP.Entities.Patient;
using SDHP.Identity;
using SDHP.Models;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.Patient;
using SDHP.ViewModel.Company;
using SDHP.ViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SDHP.Controllers
{
    [RoutePrefix("api/Patient")]
    public class PatientController : BaseApiController
    {
        public PatientController(IPatientService iPatientService, IUnitOfWork unitOfWork,ICommonServices iCommonServices)
        {
          
            //_repo = new StudentRepository();
            _iPatientService = iPatientService;
            _unitOfWork = unitOfWork;
            _iCommonService = iCommonServices;
        }
        /// <summary>
        /// Created By Priyanka Chandak
        /// Get the List of Patient
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPatientList")]
        public IHttpActionResult GetList()
        {
            //Testing
           // _iCommonService.SendMails("", "", "");

            ResponseModel<List<PatientViewModel>> Response = null;
            List<PatientViewModel> ReturnObject = null;
            try
            {
            
                List<PatientBasicDetails> PatientList = _iPatientService.GetAllPatients(ref ErrorMessage);
                if (PatientList != null)
                {
                    ReturnObject = new List<PatientViewModel>();
                    //foreach (PatientBasicDetails DBData in PatientList)
                    //{
                        ReturnObject = Mapper.Map<List<PatientBasicDetails>,List<PatientViewModel>>(PatientList);

                   // }

                }
            }
            catch (Exception )
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<PatientViewModel>>()
            {
                Response = ReturnObject,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return Content((HttpStatusCode)Response.ResponseCode, Response);
        }

        /// <summary>
        /// Created By Priyanka Chandak
        /// Add or Update Patient details.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdatePatient")]
        public async Task<IHttpActionResult> Post(PatientViewModel data)
        {
           
            ResponseModel<PatientViewModel> Response = new ResponseModel<PatientViewModel>();
            PatientViewModel ResponseData = null;
            try
            {
                //long CompanyID = CompanyInfo.ID;
               // data.CompanyID = CompanyID;

                PatientBasicDetails DBData = _iPatientService.SavePatientDetails(data, ref ErrorMessage);
                //UserModel userModel = new UserModel()
                //{
                //    UserName = "John123456",
                //    Email = "John123456@gmail.com"
                //};
                //IdentityResult result = await _repo.RegisterUser(userModel);
                //ResponseData = AT.Data.Convert<TimeBreakViewModel>(DBData);
                if (DBData != null)
                {
                    ResponseData = Mapper.Map<PatientBasicDetails, PatientViewModel>(DBData);
                }
            }
            catch (Exception Ex) { ErrorMessage = Ex.Message; }

            Response = new ResponseModel<PatientViewModel>()
            {
                Response = ResponseData,
                Message = ErrorMessage,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return await Task.FromResult(Content((HttpStatusCode)Response.ResponseCode, Response));
        }

        /// <summary>
        /// Created By Priyanka Chandak
        /// Get the Patient according to ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByID")]
        public async Task<IHttpActionResult> Get(string id)
        {
            ResponseModel<PatientViewModel> Response = null;
            PatientViewModel ReturnObject = null;

            
           // long converted_id = Convert.ToInt64(Convert.ToDecimal(id));
            long OriginalID = 0;
            Byte[] GetByteID = Encoding.ASCII.GetBytes(id);
             if (!id.Equals(null))
            {
              //  PatientBasicDetails DBData = _iPatientService.GetPatientByID(converted_id, ref ErrorMessage);
                using (Aes myAes = Aes.Create())
                {
                    // Decrypt the string to an array of bytes.
                    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(GetByteID, myAes.Key, myAes.IV).ToString();
                    OriginalID = int.Parse(decpt);
                }
                PatientBasicDetails DBData = _iPatientService.GetPatientByID(OriginalID, ref ErrorMessage);


                if (DBData != null)
                {
                    ReturnObject = Mapper.Map<PatientBasicDetails, PatientViewModel>(DBData);
                }
            }
            else
            {
                ReturnObject = new PatientViewModel();
            }

            Response = new ResponseModel<PatientViewModel>()
            {
                Response = ReturnObject,
                Message = ErrorMessage,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return await Task.FromResult(Content((HttpStatusCode)Response.ResponseCode, Response));
        }

        /// <summary>
        ///  Created By Priyanka Chandak
        ///  Delete the Patient according to ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("SoftDeleteDeletePatientDetails")]
        public async Task<IHttpActionResult> Delete(string id)
        {

            long converted_id = Convert.ToInt64(Convert.ToDecimal(id));

            ResponseModel<bool?> Response = null;
            bool? DataRemoved = null;
            long OriginalID = 0;
            if (id != null)
            {
                DataRemoved = _iPatientService.SoftDeletePatientDetails(converted_id, ref ErrorMessage);

                //Byte[] GetByteID = Encoding.ASCII.GetBytes(id);
                //using (Aes myAes = Aes.Create())
                //{
                //    // Decrypt the string to an array of bytes.
                //    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(GetByteID, myAes.Key, myAes.IV).ToString();
                //    OriginalID = int.Parse(decpt);
                //}

                //DataRemoved = _iPatientService.SoftDeletePatientDetails(OriginalID, ref ErrorMessage);
            }
            
            Response = new ResponseModel<bool?>()
            {
                Response = DataRemoved,
                Message = ErrorMessage,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };

            return await Task.FromResult(Content((HttpStatusCode)Response.ResponseCode, Response));
        }



     
    }
}
