using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Company
{
    public class CompanyContactDetails : IEntityBase
    {

        /// <summary>
        /// Get or Set property to hold ID
        /// </summary>      
        [Key]
        public long ID
        {
            get;
            set;
        }
        /// <summary>
        /// Get or set property for CompanyID(ForeignKey From CompanyBasicInfo)
        /// </summary>
        public long CompanyID { get; set; }
        /// <summary>
        /// Get or set Email of Comapany
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Get or set the Contact Number
        /// </summary>
        public int ContactNumber { get; set; }
        /// <summary>
        /// Get or Set the alternate Contact Number
        /// </summary>
        public int AlternateContactNumber { get; set; }
        /// <summary>
        /// Get or set the Fax number
        /// </summary>
        public long FaxNumber { get; set; }
        /// <summary>
        /// Get or set website URl if any
        /// </summary>
        public string Website { get; set; }
       
        /// <summary>
        /// Gets or sets the company has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets flag to identify the Company is deleted or not. 
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
