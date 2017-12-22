using System.Configuration;

namespace SDHP.Service.EmailConfiguration
{
    /// <summary>
    /// Class SMTPProvider.
    /// </summary>
    public static class SMTPProvider
    {
        private static System.Collections.Specialized.NameValueCollection configSettings = ConfigurationManager.AppSettings;

        /// <summary>
        /// The provider URL
        /// </summary>
        public static string ProviderURL = configSettings["ProviderURL"];
        /// <summary>
        /// The provider email
        /// </summary>
        public static string ProviderEmail = configSettings["ProviderEmail"];
        public static string PretendProviderEmail = configSettings["PretendProviderEmail"];
        /// <summary>
        /// The provider password
        /// </summary>
        public static string ProviderPassword = configSettings["ProviderPassword"];
    }
}
