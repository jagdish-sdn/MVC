using AutoMapper;
using SDHP.Entities.CommonEntities;
using SDHP.Entities.Company;
using SDHP.Entities.Masters;
using SDHP.Entities.Patient;
using SDHP.Entities.Professional;
using SDHP.Entities.Professional.CareCoOrdinator;
using SDHP.Entities.Professional.FamilyHistories;
using SDHP.ViewModel.CommonEntities;
using SDHP.ViewModel.Company;
using SDHP.ViewModel.EntityMaster;
using SDHP.ViewModel.Patient;
using SDHP.ViewModel.Professional;
using SDHP.ViewModel.Professional.CareCoOrdinator;
using SDHP.ViewModel.Professional.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDHP.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        
        protected override void Configure()
        {
            CreateMap<CompanyBasicInfoViewModel, CompanyBasicInfo>();

            CreateMap<PatientViewModel, PatientBasicDetails>();
            CreateMap<PatientAddressDetailsViewModel,PatientAddressDetails>();
            CreateMap<PatientContactDetailsViewModel, PatientContactDetails>();
            CreateMap<PatientAppointmentDetailsViewModel, PatientAppointmentDetails>();
           // CreateMap<PatientBasicDetailsViewModel, PatientBasicDetails>();
            CreateMap<PatientUploadDetailsViewModel, PatientDocumentsUploadDetails>();
            CreateMap< ProfessionalBuisnessControlViewModel, ProfessionalBuisnessControl>();

            CreateMap< _CountryLookupViewModel, _CountryLookup>();
            CreateMap<_StateLookupViewModel,_StateLookup>();
            //CreateMap<_DistrictLookupViewModel, _DistrictLookup>();
            //CreateMap<_CityLookupViewModel, _CityLookup>();
            CreateMap<CategoryViewModel,Category>();
            CreateMap<FamilyHistoryViewModel, FamilyHistory>();
            CreateMap<CareCoordinatorViewModel, CareCoordinator>();
            //  CreateMap<ProfessionalBasicDetailsViewModel, ProfessionalBasicDetails>();

            CreateMap<ProfessionalViewModel, ProfessionalBasicDetails>();
            CreateMap<ProfessionalAddressDetailsViewModel, ProfessionalAddressDetails>();
            CreateMap<ProfessionalContactDetailsViewModel, ProfessionalContactDetails>();
            CreateMap<ProfessionalJoiningDetailsViewModel, ProfessionalJoiningDetails>();
            CreateMap<ProfessionalProfileImageViewModel, ProfessionalProfileImages>();

           

        }
    }
}