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
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<CompanyBasicInfo, CompanyBasicInfoViewModel>();
            CreateMap<PatientBasicDetails, PatientViewModel>();
            CreateMap<PatientAddressDetails, PatientAddressDetailsViewModel>();
            CreateMap<PatientContactDetails,PatientContactDetailsViewModel>();
            CreateMap<PatientAppointmentDetails,PatientAppointmentDetailsViewModel>();
            CreateMap<PatientDocumentsUploadDetails,PatientUploadDetailsViewModel>();
            CreateMap<ProfessionalBuisnessControl, ProfessionalBuisnessControlViewModel>();
            CreateMap<_CountryLookup, _CountryLookupViewModel>();
            CreateMap<_StateLookup, _StateLookupViewModel>();
            CreateMap<ProfessionalBasicDetails, ProfessionalViewModel>();
            CreateMap<ProfessionalAddressDetails, ProfessionalAddressDetailsViewModel>();
            CreateMap<ProfessionalContactDetails, ProfessionalContactDetailsViewModel>();
            CreateMap<ProfessionalJoiningDetails, ProfessionalJoiningDetailsViewModel>();
            CreateMap<ProfessionalProfileImages, ProfessionalProfileImageViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<FamilyHistory, FamilyHistoryViewModel>();
            CreateMap<CareCoordinator, CareCoordinatorViewModel>();

        }
    }
    public class NullStringConverter : ITypeConverter<string, string>
    {
        public string Convert(string source, ResolutionContext context)
        {
            return source ?? string.Empty;
        }

        public string Convert(string source, string destination, ResolutionContext context)
        {
            return source ?? string.Empty;
        }
    }
}