using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Company
{
    public class CompanyAddressDetails : IEntityBase
    {
        /// <summary>
        ///  Get or Set property to hold ID
        /// </summary>
        [Key]
        public long ID
        {
            get;
            set;
        }
        /// <summary>
        /// Get or set the companyID (Foreign key of CompanyBasicInfo)
        /// </summary>
        public string CompanyID { get; set; }
        /// <summary>
        /// Get or set the Address Line-1
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Get or set Address Line-2
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Get or set the Country ID of company
        /// </summary>
        public long Country { get; set; }
        /// <summary>
        /// Get or set the State ID of company
        /// </summary>
        public long State { get; set; }
        /// <summary>
        /// Get or set the Distric ID of Company
        /// </summary>
        public long District { get; set; }
        /// <summary>
        /// Get or set City of company
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Get or set ZipCode of Company
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the company has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate
        {
            get;
            set;
          
        }       
        /// <summary>
        /// Gets or sets flag to identify the Company Address Details is deleted or not. 
        /// </summary>
        public bool? IsDeleted
        {
            get;
            set;
        }
        /// <summary>
        ///  Gets or sets the company has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID
        {
            get;
            set;
        }
    }
}
