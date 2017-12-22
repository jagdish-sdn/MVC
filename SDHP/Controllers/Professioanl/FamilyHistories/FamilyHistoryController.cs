using AutoMapper;
using SDHP.Entities.Professional.FamilyHistories;
using SDHP.Models;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.Professional.FamilyHistories;
using SDHP.ViewModel.Professional.FamilyHistories;
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

namespace SDHP.Controllers.Professioanl.FamilyHistories
{
    [RoutePrefix("api/FamilyHistory")]
    public class FamilyHistoryController : BaseApiController
    {
        public FamilyHistoryController(IFamilyHistoryService iFamilyHistoryService, IUnitOfWork unitOfWork, ICommonServices iCommonServices)
        {

            //_repo = new StudentRepository();
            _iFamilyHistoryService = iFamilyHistoryService;
            _unitOfWork = unitOfWork;
            _iCommonService = iCommonServices;
        }
        [HttpGet]
        [Route("GetAllFamilyList")]
        public IHttpActionResult GetList()
        {
            ResponseModel<List<FamilyHistoryViewModel>> Response = null;
            List<FamilyHistoryViewModel> ReturnObject = null;
            try
            {
                List<FamilyHistory> FamilyHistoryList = _iFamilyHistoryService.GetAllFamilyHistory(ref ErrorMessage);
                if (FamilyHistoryList != null)
                {
                    ReturnObject = new List<FamilyHistoryViewModel>();
                    ReturnObject = Mapper.Map<List<FamilyHistory>, List<FamilyHistoryViewModel>>(FamilyHistoryList);
                }
            }
            catch (Exception)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<FamilyHistoryViewModel>>()
            {
                Response = ReturnObject,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return Content((HttpStatusCode)Response.ResponseCode, Response);
        }
        /// <summary>
        /// Created By Kanchan Gadge
        /// Add or Update Patient details.
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[Route("AddUpdateFamilyHistory")]
        //public async Task<IHttpActionResult> Post(FamilyHistoryViewModel data)
        //{

        //    ResponseModel<FamilyHistoryViewModel> Response = new ResponseModel<FamilyHistoryViewModel>();
        //    FamilyHistoryViewModel ResponseData = null;
        //    try
        //    {
        //        FamilyHistory DBData = _iFamilyHistoryService.SaveFamilyHistoryDetails(data, ref ErrorMessage);

        //        if (DBData != null)
        //        {
        //            DBData.RecordID = Guid.NewGuid();
        //            ResponseData = Mapper.Map<FamilyHistory, FamilyHistoryViewModel>(DBData);
        //        }
        //    }
        //    catch (Exception Ex) { ErrorMessage = Ex.Message; }

        //    Response = new ResponseModel<FamilyHistoryViewModel>()
        //    {
        //        Response = ResponseData,
        //        Message = ErrorMessage,
        //        ResponseCode = HttpContext.Current.Response.StatusCode,
        //        ResponseDescription = HttpContext.Current.Response.StatusDescription,
        //        SubStatusCode = HttpContext.Current.Response.SubStatusCode
        //    };
        //    return await Task.FromResult(Content((HttpStatusCode)Response.ResponseCode, Response));
        //}

        [HttpPost]
        [Route("AddUpdateFamilyHistory")]
        public HttpResponseMessage AddUpdateFamilyHistory(FamilyHistoryViewModel data)
        {

            try
            {
                ResponseCodeModel ResponseData = new ResponseCodeModel();
                FamilyHistory DBData = _iFamilyHistoryService.SaveFamilyHistoryDetails(data, ref ErrorMessage);
                if (DBData != null)
                {
                    ResponseData.Data = DBData;
                    DBData.RecordID = Guid.NewGuid();
                    return HttpOkRequest(ResponseData);
                }
                ResponseData.Data = null;
                ResponseData.Message = "No Record Found";
                return HttpBadRequest(ResponseData);
            }
            catch (Exception Ex) { return HttpResponseError(Ex); }


        }
        /// <summary>
        /// Created By Kanchan Gadge
        /// Get the Patient according to ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFamilyHistoryByID")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            ResponseModel<FamilyHistoryViewModel> Response = null;
            FamilyHistoryViewModel ReturnObject = null;
             if (!id.Equals(null))
            {
                FamilyHistory DBData = _iFamilyHistoryService.GetFamilyHistoryByID(id.ToString(), ref ErrorMessage);
                if (DBData != null)
                {
                    ReturnObject = Mapper.Map<FamilyHistory, FamilyHistoryViewModel>(DBData);
                }
            }
            else
            {
                ReturnObject = new FamilyHistoryViewModel();
            }

            Response = new ResponseModel<FamilyHistoryViewModel>()
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
        ///  Created By Kanchan Gadge
        ///  Delete the Patient according to ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("SoftDeleteFamilyHistoryDetails")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            //long converted_id = Convert.ToInt64(Convert.ToDecimal(id));
            ResponseModel<bool?> Response = null;
            bool? DataRemoved = null;
           // long OriginalID = 0;
            if (id != null)
            {
                DataRemoved = _iFamilyHistoryService.SoftDeleteFamilyHistory(id, ref ErrorMessage);
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
