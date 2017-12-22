using AutoMapper;
using SDHP.Entities.Professional;
using SDHP.Models;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.ViewModel.Patient;
using SDHP.ViewModel.Professional;
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
    [RoutePrefix("api/Professional")]
    public class ProfessionalController : BaseApiController
    {
        public ProfessionalController(IProfessionalService iProfessionalService, IUnitOfWork unitOfWork, ICommonServices iCommonServices)
        {
            //_repo = new StudentRepository();
            _iProfessionalService = iProfessionalService;
            _unitOfWork = unitOfWork;
            _iCommonService = iCommonServices;
        }
        /// <summary>
        /// Created By Saurabh Wanjari
        /// Get the List Professional basic details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProfessionalList")]
        public IHttpActionResult GetProfessionalList()
        {
            ResponseModel<List<ProfessionalViewModel>> Response = null;
            List<ProfessionalViewModel> ReturnObject = null;
            try
            {
                List<ProfessionalBasicDetails> ProfessionalListList = _iProfessionalService.getProfessionalList(ref ErrorMessage);
                if (ProfessionalListList != null)
                {
                    ReturnObject = new List<ProfessionalViewModel>();

                    ReturnObject = Mapper.Map<List<ProfessionalBasicDetails>, List<ProfessionalViewModel>>(ProfessionalListList);
                }
            }
            catch (Exception e)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<ProfessionalViewModel>>()
            {
                Response = ReturnObject,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return Content((HttpStatusCode)Response.ResponseCode, Response);
        }

        /// <summary>
        /// Created By Saurabh Wanjari
        /// Get the List Professional basic details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateProfessionalBasicDetails")]
       public async Task<IHttpActionResult> AddUpdateProfessionalBasicDetails(ProfessionalViewModel data)
          //  public async Task<IHttpActionResult> AddUpdateProfessionalBasicDetails(ProfessionalBasicDetailsViewModel data)

        {

          ResponseModel<ProfessionalViewModel> Response = new ResponseModel<ProfessionalViewModel>();
            ProfessionalViewModel ResponseData = null;
           // ResponseModel<ProfessionalBasicDetailsViewModel> Response = new ResponseModel<ProfessionalBasicDetailsViewModel>();
            //ProfessionalBasicDetailsViewModel ResponseData = null;

           try
            {

                ProfessionalBasicDetails DBData = _iProfessionalService.SaveProfessionalBasicDetails(data, ref ErrorMessage);
                 ResponseData = Mapper.Map<ProfessionalBasicDetails, ProfessionalViewModel>(DBData);
                //ResponseData = Mapper.Map<ProfessionalBasicDetails, ProfessionalBasicDetailsViewModel>(DBData);
            }
            catch (Exception Ex) { ErrorMessage = Ex.Message; }

            Response = new ResponseModel<ProfessionalViewModel>()
            //Response = new ResponseModel<ProfessionalBasicDetailsViewModel>()

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
        /// Created By Saurabh Wanjari
        /// Get the single Professional basic details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProfessionalBasicByID")]
        public async Task<IHttpActionResult> GetProfessionalBasic(string id)
        {
            ResponseModel<ProfessionalViewModel> Response = null;
            ProfessionalViewModel ReturnObject = null;


            long converted_id = Convert.ToInt64(Convert.ToDecimal(id));
            long OriginalID = 0;
            Byte[] GetByteID = Encoding.ASCII.GetBytes(id);
            if (!id.Equals(null))
            {
                ProfessionalBasicDetails DBData = _iProfessionalService.GetProfessionalBasicDetailByID(converted_id, ref ErrorMessage);
                // using (Aes myAes = Aes.Create())
                // {
                //// Decrypt the string to an array of bytes.
                //    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(GetByteID, myAes.Key, myAes.IV).ToString();
                // OriginalID = int.Parse(decpt);
                // }
                //   ProfessionalBasicDetails DBData = _iProfessionalService.GetProfessionalBasicDetailByID(OriginalID, ref ErrorMessage);                           


                if (DBData != null)
                {
                    ReturnObject = Mapper.Map<ProfessionalBasicDetails, ProfessionalViewModel>(DBData);
                }
            }
            else
            {
                ReturnObject = new ProfessionalViewModel();
            }

            Response = new ResponseModel<ProfessionalViewModel>()
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
        /// Created By Saurabh Wanjari
        /// Get the single Professional basic details
        /// </summary>
        /// <returns></returns>
        [HttpDelete]        
        [Route("SoftDeleteProfessionalBasicDetails")]
        public async Task<IHttpActionResult> DeleteProfessionalBasic(string id)
        {

           long converted_id = Convert.ToInt64(Convert.ToDecimal(id));

            ResponseModel<bool?> Response = null;
            bool? DataRemoved = null;
            //long OriginalID = 0;

           DataRemoved = _iProfessionalService.SoftDeleteProfessionalBasicDetails(converted_id, ref ErrorMessage);
            //if (id != null)
            // {
            //      DataRemoved = _iProfessionalService.SoftDeleteProfessionalBasicDetails(id, ref ErrorMessage);

            //Byte[] GetByteID = Encoding.ASCII.GetBytes(id);
            //using (Aes myAes = Aes.Create())
            //{
            //    // Decrypt the string to an array of bytes.
            //    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(GetByteID, myAes.Key, myAes.IV).ToString();
            //    OriginalID = int.Parse(decpt);
            //}

            //DataRemoved = _iProfessionalService.SoftDeleteProfessionalBasicDetails(OriginalID, ref ErrorMessage);
            //}

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



        /// <summary>
        /// Created By Priyanka Chandak
        /// Get the List of Buisness Control
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBuisnessControlList")]
        public IHttpActionResult GetList()
        {         
            ResponseModel<List<ProfessionalBuisnessControlViewModel>> Response = null;
            List<ProfessionalBuisnessControlViewModel> ReturnObject = null;
            try
            {
                List<ProfessionalBuisnessControl> BuisnessControlList = _iProfessionalService.getProfessionalBuisnessControl(ref ErrorMessage);
                if (BuisnessControlList != null)
                {
                    ReturnObject = new List<ProfessionalBuisnessControlViewModel>();
                    
                    ReturnObject = Mapper.Map<List<ProfessionalBuisnessControl>, List<ProfessionalBuisnessControlViewModel>>(BuisnessControlList);
                }
            }
            catch (Exception e)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<ProfessionalBuisnessControlViewModel>>()
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
        /// Add or Update Buisness Control details.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateBuisnessControl")]
        public async Task<IHttpActionResult> Post(ProfessionalBuisnessControlViewModel data)
        {

            ResponseModel<ProfessionalBuisnessControlViewModel> Response = new ResponseModel<ProfessionalBuisnessControlViewModel>();
            ProfessionalBuisnessControlViewModel ResponseData = null;
            try
            {         
                                 
                ProfessionalBuisnessControl DBData = _iProfessionalService.SaveBuisnessControl(data, ref ErrorMessage);              
                ResponseData = Mapper.Map<ProfessionalBuisnessControl, ProfessionalBuisnessControlViewModel>(DBData);
            }
            catch (Exception Ex) { ErrorMessage = Ex.Message; }

            Response = new ResponseModel<ProfessionalBuisnessControlViewModel>()
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
        /// Get the Buisness Control according to ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByID")]
        public async Task<IHttpActionResult> Get(string id)
        {
            ResponseModel<ProfessionalBuisnessControlViewModel> Response = null;
            ProfessionalBuisnessControlViewModel ReturnObject = null;
            long OriginalID = 0;
            Byte[] GetByteID = Encoding.ASCII.GetBytes(id);
            if (!id.Equals(null))
            {  using (Aes myAes = Aes.Create())
                {
                    // Decrypt the string to an array of bytes.
                    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(GetByteID, myAes.Key, myAes.IV).ToString();
                    OriginalID = int.Parse(decpt);
                }
                //  string userid = PublicProcedures.Encipher.Decrypt<string>(id);
                ProfessionalBuisnessControl DBData = _iProfessionalService.GetProfessionalByID(OriginalID, ref ErrorMessage);
                if (DBData != null)
                {
                    ReturnObject = Mapper.Map<ProfessionalBuisnessControl, ProfessionalBuisnessControlViewModel>(DBData);
                }
            }
            else
            {
                ReturnObject = new ProfessionalBuisnessControlViewModel();
            }

            Response = new ResponseModel<ProfessionalBuisnessControlViewModel>()
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
        /// Created By Priyanka Chandak
        /// Solf Delete Buisness Control
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteBuisnessControlDetails")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            ResponseModel<bool?> Response = null;
            bool? DataRemoved = null;
            long OriginalID = 0;
            if (id != null)
            {
                Byte[] GetByteID = Encoding.ASCII.GetBytes(id);
                using (Aes myAes = Aes.Create())
                {
                    // Decrypt the string to an array of bytes.
                    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(GetByteID, myAes.Key, myAes.IV).ToString();
                    OriginalID = int.Parse(decpt);
                }

                DataRemoved = _iProfessionalService.SoftDeleteProfessionalDetails(OriginalID, ref ErrorMessage);
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
        /// <summary>
        /// Created By Priyanka Chandak
        /// Delete Buisness Control
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteProfessionalBuisnessDetails")]
        public async Task<IHttpActionResult> Delete(string id, string nullValue)
        {
            ResponseModel<bool?> Response = null;
            bool? DataRemoved = null;
            List<long> Ids = new List<long>();
            long OriginalID = 0;
            if (id != null)
            {
                Byte[] GetByteID = Encoding.ASCII.GetBytes(id);
                using (Aes myAes = Aes.Create())
                {
                    // Decrypt the string to an array of bytes.
                    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(GetByteID, myAes.Key, myAes.IV).ToString();
                    OriginalID = int.Parse(decpt);
                }
                DataRemoved = _iProfessionalService.RemoveProfessionalBuisnessControl(OriginalID, ref ErrorMessage);
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
