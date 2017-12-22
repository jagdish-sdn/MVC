using SDHP.Entities.Masters;
using SDHP.ViewModel.EntityMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Abstract.EntityMasters
{
    public interface ICategoryServices
    {
        List<Category> GetAllCategory(ref string errorMessage);
        Category SaveCategory(CategoryViewModel data, ref string errorMessage);
        Category GetCategoryByID(long ID, ref string errorMessage);
        bool? SoftDeleteCategoryDetails(long id, ref string errorMessage);
    }
}
