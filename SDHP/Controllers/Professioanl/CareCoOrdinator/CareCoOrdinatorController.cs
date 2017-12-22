using AutoMapper;
using SDHP.Entities.Professional.CareCoOrdinator;
using SDHP.Models;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.Professional.CareCoOrdinator;
using SDHP.ViewModel.Professional.CareCoOrdinator;
using SDHP.ViewModel.Professional.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SDHP.Controllers.Professioanl.CareCoOrdinator
{
    [RoutePrefix("api/CareCoordinator")]
    public class CareCoOrdinatorController : BaseApiController
    {
        public CareCoOrdinatorController(ICareCoordinatorService iCareCoordinatorService, IUnitOfWork unitOfWork, ICommonServices iCommonServices)
        {
            _iCareCoodinatorService = iCareCoordinatorService;
            _unitOfWork = unitOfWork;
            _iCommonService = iCommonServices;
        }
        [HttpGet]
        [Route("GetAllCareCoordinatorList")]
        public IHttpActionResult GetList()
        {
            ResponseModel<List<CareCoordinatorViewModel>> Response = null;
            List<CareCoordinatorViewModel> ReturnObject = null;
            try
            {
                List<CareCoordinator> CareCoordinatorList = _iCareCoodinatorService.GetAllCareCoordinator(ref ErrorMessage);
                if (CareCoordinatorList != null)
                {
                    ReturnObject = new List<CareCoordinatorViewModel>();
                    ReturnObject = Mapper.Map<List<CareCoordinator>, List<CareCoordinatorViewModel>>(CareCoordinatorList);
                }
            }
            catch (Exception)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<CareCoordinatorViewModel>>()
            {
                Response = ReturnObject,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return Content((HttpStatusCode)Response.ResponseCode, Response);
        }
        [HttpPost]
        [Route("AddUpdateCareCoordinator")]
        public HttpResponseMessage AddUpdateCareCoordinator(CareCoordinatorViewModel data)
        {

            try
            {
                ResponseCodeModel ResponseData = new ResponseCodeModel();
                CareCoordinator DBData = _iCareCoodinatorService.SaveCareCoordinatorDetails(data, ref ErrorMessage);
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
        [HttpGet]
        [Route("GetCareCoordinatorByID")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            ResponseModel<CareCoordinatorViewModel> Response = null;
            CareCoordinatorViewModel ReturnObject = null;
            if (!id.Equals(null))
            {
                CareCoordinator DBData = _iCareCoodinatorService.GetCareCoordinatorByID(id.ToString(), ref ErrorMessage);
                if (DBData != null)
                {
                    ReturnObject = Mapper.Map<CareCoordinator, CareCoordinatorViewModel>(DBData);
                }
            }
            else
            {
                ReturnObject = new CareCoordinatorViewModel();
            }

            Response = new ResponseModel<CareCoordinatorViewModel>()
            {
                Response = ReturnObject,
                Message = ErrorMessage,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return await Task.FromResult(Content((HttpStatusCode)Response.ResponseCode, Response));
        }
        [HttpDelete]
        [Route("SoftDeleteCareCoordinatorDetails")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            ResponseModel<bool?> Response = null;
            bool? DataRemoved = null;
            if (id != null)
            {
                DataRemoved = _iCareCoodinatorService.SoftDeleteCareCoordinator(id, ref ErrorMessage);
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