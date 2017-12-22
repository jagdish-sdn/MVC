using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Professional
{
   public class ProfessionalAddressDetails:IEntityBase
    {
        [Key]
        /// <summary>
        /// Get or Set property to hold ID
        /// </summary>
        public long ID { get; set; }    

        /// <summary>
        /// Get or Set Unique Professional ID(GUID)
        /// </summary>
        public long ProfessionalID { get; set; }
        /// <summary>
        /// Get or set the Company ID(Foreign key )
        /// </summary>
        public long CompanyID { get; set;}
        /// <summary>
        /// Get or set the Professional Address Line-1
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Get or set the Professional Address Line-2
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Get or Set the professional Country
        /// </summary>
        public long Country { get; set; }
        /// <summary>
        /// Get or set the professioanl State
        /// </summary>
        public long State { get; set; }
        /// <summary>
        /// Get or the District of professional
        /// </summary>
        public long District { get; set; }
        /// <summary>
        /// Get or set the professional City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Get or set the 
        /// </summary>
        public long ZipCode { get; set; }
       
        /// <summary>
        /// Gets or sets flag to identify the Professional is deleted or not. 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        ///  Gets or sets the Professional has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID { get; set; }
        /// <summary>
        /// Gets or sets the Professional has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
    }
}
