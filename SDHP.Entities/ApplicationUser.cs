using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SDHP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities
{
   public class ApplicationUser: IdentityUser
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long UserID
        //{
        //    get { return UserID; }
        //    set
        //    {
        //        UserID = value;
        //        if (value != 0)
        //        {

        //            using (Aes myAes = Aes.Create())
        //            {
        //                // Encrypt the string to an array of bytes.
        //                QuerystringID = PublicProcedure.EncryptStringToBytes_Aes(UserID.ToString(), myAes.Key, myAes.IV).ToString();

        //            }
        //        }
        //    }
        //}
        //public string QuerystringID { get; set; }

    }
}
