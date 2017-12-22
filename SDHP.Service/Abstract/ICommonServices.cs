using SDHP.Entities.CommonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Abstract
{
    public interface ICommonServices
    {
        void SendMails(string toEmail, string subject, string body);

        List<_CountryLookup> GetConuntries { get; }
        List<_CountryLookup> GetAllCountries(ref string errorMessage);
        List<_StateLookup> GetPatientByID(long ID, ref string errorMessage);
        List<_DistrictLookup> GetDistrictByID(long ID, ref string errorMessage);
        List<_CityLookup> GetCityByID(long ID, ref string errorMessage);

    }
}
