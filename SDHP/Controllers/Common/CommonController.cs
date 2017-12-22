using AutoMapper;
using SDHP.Entities.CommonEntities;
using SDHP.Models;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.ViewModel.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SDHP.Controllers.Common
{
    [RoutePrefix("api/Common")]
    public class CommonController : BaseApiController
    {

        public CommonController(IUnitOfWork unitOfWork, ICommonServices iCommonServices)
        {


            _unitOfWork = unitOfWork;
            _iCommonService = iCommonServices;
        }

        /// <summary>
        /// Created By Priyanka Chandak
        /// Get the List of Countries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCountries")]
        public IHttpActionResult GetList()
        {

            ResponseModel<List<_CountryLookupViewModel>> Response = null;
            List<_CountryLookupViewModel> ReturnObject = null;
            try
            {
                List<_CountryLookup> CountryList = _iCommonService.GetAllCountries(ref ErrorMessage);
                if (CountryList != null)
                {
                    ReturnObject = new List<_CountryLookupViewModel>();
                    ReturnObject = Mapper.Map<List<_CountryLookup>, List<_CountryLookupViewModel>>(CountryList.ToList());
                }
            }
            catch (Exception)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<_CountryLookupViewModel>>()
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
        /// Get the States according to ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStatesByID")]
      

        public IHttpActionResult GetState(long id)
        {

            ResponseModel<List<_StateLookupViewModel>> Response = null;
            List<_StateLookupViewModel> ReturnObject = null;
            try
            {
                List<_StateLookup> CountryList = _iCommonService.GetPatientByID(id,ref ErrorMessage);
                if (CountryList != null ||CountryList.Count!=0)
                {
                    ReturnObject = new List<_StateLookupViewModel>();
                    ReturnObject = Mapper.Map<List<_StateLookup>, List<_StateLookupViewModel>>(CountryList);
                }
            }
            catch (Exception e)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<_StateLookupViewModel>>()
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
        /// Get the District according to ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDistrictByID")]
        public IHttpActionResult GetDistrict(long id)
        {

            ResponseModel<List<_DistrictLookupViewModel>> Response = null;
            List<_DistrictLookupViewModel> ReturnObject = null;
            try
            {
                List<_DistrictLookup> DistrictList = _iCommonService.GetDistrictByID(id, ref ErrorMessage);
                if (DistrictList != null || DistrictList.Count != 0)
                {
                    ReturnObject = new List<_DistrictLookupViewModel>();
                    ReturnObject = Mapper.Map<List<_DistrictLookup>, List<_DistrictLookupViewModel>>(DistrictList);
                }
            }
            catch (Exception e)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<_DistrictLookupViewModel>>()
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
        /// Get the City according to ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCityByID")]
        public IHttpActionResult GetCities(long id)
        {

            ResponseModel<List<_CityLookupViewModel>> Response = null;
            List<_CityLookupViewModel> ReturnObject = null;
            try
            {
                List<_CityLookup> DistrictList = _iCommonService.GetCityByID(id, ref ErrorMessage);
                if (DistrictList != null || DistrictList.Count != 0)
                {
                    ReturnObject = new List<_CityLookupViewModel>();
                    ReturnObject = Mapper.Map<List<_CityLookup>, List<_CityLookupViewModel>>(DistrictList);
                }
            }
            catch (Exception e)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<_CityLookupViewModel>>()
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
