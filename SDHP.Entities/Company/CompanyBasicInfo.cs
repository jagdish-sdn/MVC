using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Company
{
   public class CompanyBasicInfo: IEntityBase
    {

        /// <summary>
        /// Get or Set property to hold ID
        /// </summary>
        [Key]
        public long ID { get; set; }
        /// <summary>
       ///   Get or Set Property to hold Comapny ID
       /// </summary>
        public long CompanyID { get; set; }
        /// <summary>
        /// Get or Set property from CompanyName
        /// </summary>
        public string CompanyName  { get; set;}

        /// <summary>
        /// Get or Set Company Establishment Year.
        /// </summary>

        public DateTime EstablishmentYear { get; set; }

        /// <summary>
        ///  Get or Set Company Registration Number.
        /// </summary>
        public string RegistrationNumber { get; set;}
        /// <summary>
        ///   Get or Set to save Company Contact Details 
        /// </summary>
        public string CompanyDetails { get; set; }
        //Company Contact [contactID]  // Long
        /// <summary>
        /// Gets or sets flag to identify the Company is deleted or not. 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        ///  Gets or sets the company has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID { get; set; }
        /// <summary>
        /// Gets or sets the company has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
              

        //[ForeignKey("CompanyID")]
        //public virtual ICollection<CompanyContactDetails> ContactDetails { get; set; }

        //[ForeignKey("CompanyID")]
        //public virtual ICollection<CompanyAddressDetails> AddressDetails { get; set; }
    }
}
