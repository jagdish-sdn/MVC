using SDHP.Entities.Professional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.ViewModel.Professional
{
    public class ProfessionalBasicDetailsViewModel: ProfessionalBasicDetails

    {
        public long ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
                if (value != 0)
                {
                    // vector (IV).
                    using (Aes myAes = Aes.Create())
                    {
                        // Encrypt the string to an array of bytes.
                        QuerystringID = SDHP.Common.PublicProcedure.EncryptStringToBytes_Aes(base.ID.ToString(), myAes.Key, myAes.IV).ToString();

                    }
                }
            }
        }
        public string QuerystringID { get; set; }
    }
}
