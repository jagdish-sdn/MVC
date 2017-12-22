using SDHP.Entities.Professional.FamilyHistories;
using SDHP.ViewModel.Professional.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Abstract.Professional.FamilyHistories
{
    public interface IFamilyHistoryService
    {
        FamilyHistory SaveFamilyHistoryDetails(FamilyHistoryViewModel data, ref string errorMessage);
        List<FamilyHistory> GetAllFamilyHistory(ref string errorMessage);
        FamilyHistory GetFamilyHistoryByID(string ID, ref string errorMessage);
        bool? SoftDeleteFamilyHistory(Guid id, ref string errorMessage);
    }
}
