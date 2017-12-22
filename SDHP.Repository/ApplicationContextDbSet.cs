using SDHP.Entities;
using SDHP.Entities.CommonEntities;
using SDHP.Entities.Company;
using SDHP.Entities.Masters;
using SDHP.Entities.Patient;
using SDHP.Entities.Professional;
using SDHP.Entities.Professional.CareCoOrdinator;
using SDHP.Entities.Professional.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Repository
{
    public partial class ApplicationContext
    {
        #region DBset for Company Details

        public IDbSet<CompanyBasicInfo> CompanyBasicInfoSet { get; set; }
        public IDbSet<CompanyAddressDetails> CompanyAddressInfo { get; set; }
        public IDbSet<CompanyContactDetails> CompanyContactInfo { get; set; }
        #endregion

        #region DBset for Professional Details
        public IDbSet<ProfessionalBasicDetails> ProfessionalBasicInfo { get; set; }
        public IDbSet<ProfessionalContactDetails> ProfessionalContactInfo { get; set; }
        public IDbSet<ProfessionalAddressDetails> ProfessionalAddressInfo { get; set; }
        public IDbSet<ProfessionalJoiningDetails> ProfessionalJoiningInfo { get; set; }
        public IDbSet<ProfessionalProfileImages> ProfessionalProfileImages { get; set; }
        public IDbSet<ProfessionalBuisnessControl> ProfessionalBuisnessControlInfo { get; set; }

        public IDbSet<FamilyHistory> FamilyHistoryInfo { get; set; }
        public IDbSet<CareCoordinator> CareCoordinatorInfo { get; set; }
        #endregion
        #region DBset  for patient
        public IDbSet<PatientBasicDetails> PatientBasicInfo { get; set; }
        public IDbSet<PatientContactDetails> PatientContactInfo { get; set; }
        public IDbSet<PatientAddressDetails> PatientAddressInfo { get; set; }
        public IDbSet<PatientAppointmentDetails> PatientAppontmentInfo { get; set; }
        public IDbSet<PatientDocumentsUploadDetails> PatientDocumentUpload { get;set;}
        #endregion
        #region Masters
        public IDbSet<CategoryType> CategoryTypeInfo { get; set; }
        public IDbSet<Category> CategoryInfo { get; set; }
        #endregion
        #region LookUp 
        public IDbSet<_CountryLookup> CountryLookup { get; set; }
        public IDbSet<_StateLookup> StateLookup { get; set; }
        public IDbSet<_DistrictLookup> DistrictLookup { get; set; }
        public IDbSet<_CityLookup> CityLookup { get; set; }
        #endregion

        #region DBSet for Users
        public IDbSet<User> UserInfo { get; set; }
        public IDbSet<UserRole> UserRoleInfo { get; set; }
        #endregion

    }
}
