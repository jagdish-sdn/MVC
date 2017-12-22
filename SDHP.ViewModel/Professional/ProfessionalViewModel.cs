using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.ViewModel.Professional
{
  public  class ProfessionalViewModel: ProfessionalBasicDetailsViewModel
    {

        public List<ProfessionalContactDetailsViewModel> ContactDetails { get; set; }
        public List<ProfessionalAddressDetailsViewModel> AddressDetails { get; set; }
        public List<ProfessionalProfileImageViewModel> ProfileImage { get; set; }
        public List<ProfessionalJoiningDetailsViewModel> JoiningDetails { get; set; }

    }
}
