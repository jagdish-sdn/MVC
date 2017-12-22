using SDHP.Identity;
using SDHP.Models;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.EntityMasters;
using SDHP.Service.Abstract.Patient;
using SDHP.Service.Abstract.Professional.CareCoOrdinator;
using SDHP.Service.Abstract.Professional.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDHP.Controllers
{
    
    public class BaseApiController : ApiController
    {
        public AuthRepository _repo = null;
        protected string ErrorMessage = string.Empty;
        protected ICompanyServices _ICompanyService { get; set; }
        protected IUnitOfWork _unitOfWork { get; set; }
        protected IPatientService _iPatientService { get; set; }
        protected ICommonServices _iCommonService { get; set; }
        protected IProfessionalService _iProfessionalService { get; set; }
        protected ICategoryServices _iCategoryService { get; set; }
        protected IFamilyHistoryService _iFamilyHistoryService { get; set; }
        protected ICareCoordinatorService _iCareCoodinatorService { get; set; }
        public BaseApiController()
        {
            _repo = new AuthRepository();
        }
        public HttpResponseMessage HttpOkRequest(ResponseCodeModel processResponse)
        {
            ResponseCodeModel processedResponse = new ResponseCodeModel();
            processedResponse.Id = processResponse.Id;
            processedResponse.recordId = processResponse.recordId;
            processedResponse.Code = 200;
            processedResponse.Message = processResponse.Message;
            processedResponse.TotalRecord = processResponse.TotalRecord;
            if (processResponse.Message == null)
            {
                processedResponse.Message = "Success";
            }
            processedResponse.Status = true;
            processedResponse.Data = new string[0];
            if (processResponse.Data != null)
            {
                processedResponse.Data = processResponse.Data;
            }
            return Request.CreateResponse(HttpStatusCode.OK, processedResponse, "application/json");
        }

        public HttpResponseMessage HttpDataNotFoundRequest(ResponseCodeModel processResponse)
        {
            ResponseCodeModel processedResponse = new ResponseCodeModel();
            processedResponse.Id = processResponse.Id;
            processedResponse.recordId = processResponse.recordId;
            processedResponse.Code = 404;
            processedResponse.Message = processResponse.Message;
            processedResponse.TotalRecord = processedResponse.TotalRecord;
            if (processResponse.Message == null)
            {
                processedResponse.Message = "No data found";
            }
            processedResponse.Status = false;
            //processedResponse.Data = new string[0];
            //if (processResponse.Data != null)
            //{
            //    processedResponse.Data = processResponse.Data;
            //}
            return Request.CreateResponse(HttpStatusCode.OK, processedResponse, "application/json");
        }


        /// <summary>
        /// Method to return internal server error
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public HttpResponseMessage HttpResponseError(Exception ex)
        {
            ResponseCodeModel processedResponse = new ResponseCodeModel();
            processedResponse.Code = 500;
            processedResponse.Data = new string[0];
            processedResponse.Message = "Somethig went wrong!."; //ex.Message;
            processedResponse.Status = false;
            return Request.CreateResponse(HttpStatusCode.InternalServerError, processedResponse, "application/json");
        }

        /// <summary>
        /// Method for http bad request
        /// </summary>
        /// <param name="processedResponse"></param>
        /// <returns></returns> 
        public HttpResponseMessage HttpBadRequest(ResponseCodeModel processResponse)
        {
            ResponseCodeModel processedResponse = new ResponseCodeModel();
            processedResponse.Code = 400;
            if (processResponse.Message == null)
            {
                processedResponse.Message = "BadRequest";
            }
            processedResponse.Message = processResponse.Message;
            processedResponse.TotalRecord = processedResponse.TotalRecord;
            processedResponse.Status = false;
            if (processResponse.Data == null)
            {
                processedResponse.Data = new string[0];
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, processedResponse, "application/json");
        }

       
    }
}
