using SDHP.Entities.Professional.CareCoOrdinator;
using SDHP.ViewModel.Professional.CareCoOrdinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Abstract.Professional.CareCoOrdinator
{
    public interface ICareCoordinatorService
    {
        CareCoordinator SaveCareCoordinatorDetails(CareCoordinatorViewModel data, ref string errorMessage);
        List<CareCoordinator> GetAllCareCoordinator(ref string errorMessage);
        CareCoordinator GetCareCoordinatorByID(string ID, ref string errorMessage);
        bool? SoftDeleteCareCoordinator(Guid id, ref string errorMessage);
    }
}
