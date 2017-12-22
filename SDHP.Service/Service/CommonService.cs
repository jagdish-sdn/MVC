using SDHP.Entities.CommonEntities;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.Patient;
using SDHP.Service.EmailConfiguration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service
{
    public class CommonService : ICommonServices
    {

        protected readonly IEntityBaseRepository<_CountryLookup> _countryLookupRepo;
        protected readonly IEntityBaseRepository<_StateLookup> _stateLookup;
        protected readonly IEntityBaseRepository<_DistrictLookup> _districtLookupRepo;
        protected readonly IEntityBaseRepository<_CityLookup> _cityLookupRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CommonService(IEntityBaseRepository<_CountryLookup> CountryLookupoRepo,
            IEntityBaseRepository<_DistrictLookup> DistrictLookupRepo,
            IEntityBaseRepository<_CityLookup> CityLookupRepo,
            IEntityBaseRepository<_StateLookup> stateLookupRepo, IUnitOfWork unitOfWork)
        {
            this._countryLookupRepo = CountryLookupoRepo;
            this._stateLookup = stateLookupRepo;
            this._districtLookupRepo = DistrictLookupRepo;
            this._cityLookupRepo = CityLookupRepo;
            this._unitOfWork = unitOfWork;
        }
        #region Email
        public void SendMails(string toEmail, string subject, string body)
        {
            toEmail = "rahulit.90@gmail.com";
            subject = "TestMail";
            body = "This is test mail";
            MailMessage message = new MailMessage { From = new MailAddress(SMTPProvider.ProviderEmail) };

            message.To.Add(toEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            //message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            using (SmtpClient smtpClient = new SmtpClient(SMTPProvider.ProviderURL, 25))
            {
                if (SMTPProvider.ProviderEmail.IndexOf("gmail") > -1)
                    smtpClient.EnableSsl = true;
                else
                    smtpClient.EnableSsl = false;
                // smtpClient.auth

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtpClient.UseDefaultCredentials = false;

                if (!string.IsNullOrWhiteSpace(SMTPProvider.ProviderPassword))
                    smtpClient.Credentials = new NetworkCredential(SMTPProvider.ProviderEmail, SMTPProvider.ProviderPassword);

                try
                {
                    smtpClient.Send(message);

                    //var tempMailLog = new MailLog()
                    //{
                    //    fromEmail = SMTPProvider.ProviderEmail,
                    //    toEmail = toEmail,
                    //    Subject = subject,
                    //    Body = body,
                    //    CreatedDate = DateTime.UtcNow,
                    //    ModifiedDate = DateTime.UtcNow,
                    //    CreatedDateUnix = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    //    ModifiedDateUnix = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    //};
                    //_mailLogRepository.Add(tempMailLog);
                    //_unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    //Error _error = new Error()
                    //{
                    //    Message = ex.Message,
                    //    StackTrace = ex.StackTrace,
                    //    CreatedDate = DateTime.UtcNow,
                    //    ModifiedDate = DateTime.UtcNow,
                    //    CreatedDateUnix = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    //    ModifiedDateUnix = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    //};

                    //_errorRepository.Add(_error);
                    //_unitOfWork.Commit();
                }
            }
        }
        #endregion

        //Use get properties for master services
        public List<_CountryLookup> GetConuntries
        {
            get
            {
                try
                {
                    List<_CountryLookup> DBDataCollection = null;

                    DBDataCollection = _countryLookupRepo.GetAll().ToList();
                    if (DBDataCollection == null || DBDataCollection.Count() == 0)
                    {
                        return null;
                    }
                    return DBDataCollection.ToList();

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public List<_CountryLookup> GetAllCountries(ref string errorMessage)
        {
            try
            {
                List<_CountryLookup> DBDataCollection = null;

                DBDataCollection = _countryLookupRepo.GetAll().ToList();
                if (DBDataCollection == null || DBDataCollection.Count() == 0)
                {
                    return null;
                }
                return DBDataCollection.ToList();

            }
            catch (Exception Ex) { errorMessage = Ex.Message; }
            return null;
        }
        public List<_StateLookup> GetPatientByID(long ID, ref string errorMessage)
        {
            try
            {
                if (ID != 0)
                {
                    List<_StateLookup> data = _stateLookup.Get(x => (x.CountryID == ID), ref errorMessage).ToList();
                    return data.ToList();
                }
                else {
                    return null;
                }
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }
        public List<_DistrictLookup> GetDistrictByID(long ID, ref string errorMessage)
        {
            try
            {
                if (ID != 0)
                {
                    List<_DistrictLookup> data = _districtLookupRepo.Get(x => (x.StateID == ID), ref errorMessage).ToList();
                    return data.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }
        public List<_CityLookup> GetCityByID(long ID, ref string errorMessage)
        {
            try
            {
                if (ID != 0)
                {
                    List<_CityLookup> data = _cityLookupRepo.Get(x => (x.DistrictID == ID), ref errorMessage).ToList();
                    return data.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception Ex) { errorMessage = Ex.Message; }

            return null;
        }

    }
}
