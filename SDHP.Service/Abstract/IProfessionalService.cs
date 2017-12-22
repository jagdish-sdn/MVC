using SDHP.Entities.Professional;
using SDHP.ViewModel.Professional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Abstract
{
  public  interface IProfessionalService
    {
        List<ProfessionalBuisnessControl> getProfessionalBuisnessControl(ref string errorMessage);
        ProfessionalBuisnessControl SaveBuisnessControl(ProfessionalBuisnessControlViewModel data, ref string errorMessage);
        ProfessionalBuisnessControl GetProfessionalByID(long ID, ref string errorMessage);

        bool? SoftDeleteProfessionalDetails(long id, ref string errorMessage);
        bool? RemoveProfessionalBuisnessControl(long id, ref string errorMessage);


        /// <summary>
        /// Created By Saurabh wanjari
        /// Get All Prfessional data
        /// </summary>
        /// <returns></returns>
        List<ProfessionalBasicDetails> getProfessionalList(ref string errorMessage);
        ProfessionalBasicDetails SaveProfessionalBasicDetails(ProfessionalViewModel data, ref string errorMessage);
        ProfessionalBasicDetails GetProfessionalBasicDetailByID(long ID, ref string errorMessage);


        bool? SoftDeleteProfessionalBasicDetails(long id, ref string errorMessage);


    }
}
