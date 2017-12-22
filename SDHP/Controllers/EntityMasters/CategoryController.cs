using AutoMapper;
using SDHP.Entities.Masters;
using SDHP.Models;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.EntityMasters;
using SDHP.ViewModel;
using SDHP.ViewModel.EntityMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SDHP.Controllers.EntityMasters
{
    [RoutePrefix("api/Category")]
    public class CategoryController : BaseApiController
    {
        public CategoryController(
            ICategoryServices iCategoryServices,
            IUnitOfWork unitOfWork,
            ICommonServices iCommonServices
            )
        {
            _iCategoryService = iCategoryServices;
            _unitOfWork = unitOfWork;
            _iCommonService = iCommonServices;
        }
        /// <summary>
        /// Created By Priyanka Chandak
        /// Get the List of Patient
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategoryList")]
        public IHttpActionResult GetList()
        {
            ResponseModel<List<CategoryViewModel>> Response = null;
            List<CategoryViewModel> ReturnObject = null;
            try
            {

                List<Category> categoryList = _iCategoryService.GetAllCategory(ref ErrorMessage);
                if (categoryList != null)
                {
                    ReturnObject = new List<CategoryViewModel>();
                    //foreach (PatientBasicDetails DBData in PatientList)
                    //{
                    ReturnObject = Mapper.Map<List<Category>, List<CategoryViewModel>>(categoryList);
                    // }
                }
            }
            catch (Exception e)
            {
                ReturnObject = null;
            }
            Response = new ResponseModel<List<CategoryViewModel>>()
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
        [Route("AddUpdateCategory")]
        public async Task<IHttpActionResult> Post(CategoryViewModel data)
        {

            ResponseModel<CategoryViewModel> Response = new ResponseModel<CategoryViewModel>();
            CategoryViewModel ResponseData = null;
            try
            {
                //long CompanyID = CompanyInfo.ID;
                // data.CompanyID = CompanyID;

                Category DBData = _iCategoryService.SaveCategory(data, ref ErrorMessage);
              
                //ResponseData = AT.Data.Convert<TimeBreakViewModel>(DBData);
                ResponseData = Mapper.Map<Category, CategoryViewModel>(DBData);
            }
            catch (Exception Ex) { ErrorMessage = Ex.Message; }

            Response = new ResponseModel<CategoryViewModel>()
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
        public async Task<IHttpActionResult> Get(long id)
        {
            ResponseModel<CategoryViewModel> Response = null;
            CategoryViewModel ReturnObject = null;

            if (!id.Equals(null))
            {   //using (Aes myAes = Aes.Create())
                //{
                //    // Decrypt the string to an array of bytes.
                //    string decpt = SDHP.Common.PublicProcedure.DecryptStringFromBytes_Aes(id.ToString(), myAes.Key, myAes.IV).ToString();

                //}               
                //  string userid = PublicProcedures.Encipher.Decrypt<string>(id);
                Category DBData = _iCategoryService.GetCategoryByID(id, ref ErrorMessage);
                if (DBData != null)
                {
                    ReturnObject = Mapper.Map<Category, CategoryViewModel>(DBData);
                }
            }
            else
            {
                ReturnObject = new CategoryViewModel();
            }

            Response = new ResponseModel<CategoryViewModel>()
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
        [Route("DeleteCategoryDetails")]
        public async Task<IHttpActionResult> Delete(long id)
        {
            ResponseModel<bool?> Response = null;
            bool? DataRemoved = null;
            //foreach (string id in ids)
            //{
            //long Ids = PublicProcedures.Encipher.Decrypt<long>(ids);
            //}            

            DataRemoved = _iCategoryService.SoftDeleteCategoryDetails(id, ref ErrorMessage);
            //if()

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
