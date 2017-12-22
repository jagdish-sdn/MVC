using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.ViewModel.Patient
{
   public class PatientViewModel:PatientBasicDetailsViewModel
    {
       // public PatientBasicDetailsViewModel PatientBasicDetails { get; set; }
        public List<PatientContactDetailsViewModel> ContactDetails { get; set; }
        public List<PatientAddressDetailsViewModel> AddressDetails { get; set; }
        public List<PatientUploadDetailsViewModel> ProfileImage { get; set; }
        public List<PatientAppointmentDetailsViewModel> JoiningDetails { get; set; }

    }
}
