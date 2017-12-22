using SDHP.Entities.Patient;
using SDHP.ViewModel.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Abstract.Patient
{
   public interface IPatientService
    {
        List<PatientBasicDetails> GetAllPatients(ref string errorMessage);
        PatientBasicDetails SavePatientDetails(PatientViewModel data, ref string errorMessage);
        PatientBasicDetails GetPatientByID(long ID, ref string errorMessage);
        bool? SoftDeletePatientDetails(long id, ref string errorMessage);
     


    }
}
