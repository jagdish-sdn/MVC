using AutoMapper;
using SDHP.Entities.Company;
using SDHP.Models;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;

namespace SDHP.Controllers
{
    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        protected string ErrorMessage = string.Empty;
        private readonly ICompanyServices _iCompanyService;
        private readonly IUnitOfWork _unitOfWork;
        
        public CompanyController(ICompanyServices ICompanyService, IUnitOfWork unitOfWork)
        {
            //_repo = new StudentRepository();
            _iCompanyService = ICompanyService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetCompanyList")]
        public IHttpActionResult GetList()
        {
           
            ResponseModel<List<CompanyBasicInfoViewModel>> Response = null;
            List<CompanyBasicInfoViewModel> ReturnObject = null;
            try
            {
                List<CompanyBasicInfo> CompanyList = _iCompanyService.getAllCompany(ref ErrorMessage);
                if (CompanyList != null)
                {
                    ReturnObject = new List<CompanyBasicInfoViewModel>();
                    ReturnObject = Mapper.Map<List<CompanyBasicInfo>, List<CompanyBasicInfoViewModel>>(CompanyList.ToList());
                }
            }
            catch (Exception e)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<CompanyBasicInfoViewModel>>()
            {
                Response = ReturnObject,
                ResponseCode = HttpContext.Current.Response.StatusCode,
                ResponseDescription = HttpContext.Current.Response.StatusDescription,
                SubStatusCode = HttpContext.Current.Response.SubStatusCode
            };
            return Content((HttpStatusCode)Response.ResponseCode, Response);
        }
    }
}
