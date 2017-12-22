using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Professional
{
   public class ProfessionalContactDetails:IEntityBase
    {
        [Key]
        /// <summary>
        /// Get or Set property to hold ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Get or set the CompanyID(ForeignKey)
        /// </summary>
        public long CompanyID { get; set; }
        /// <summary>
        /// Get or set the ProfessionalID(ForeignKey)
        /// </summary>
        public long ProfessionalID { get; set; }
        /// <summary>
        /// Get or set the First Name of professional
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Get or set the Middle Name of professional
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Get or set the Last name of professional
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Get or set the Date of birth of professional
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Get or set the Email of professional
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Get or set the Maritial Status of professional(Foreign key from Lookup)
        /// </summary>
        public long MaritailStatus { get; set; }
        /// <summary>
        /// Get or set the Gender of professional(Foreign key from Lookup)
        /// </summary>
        public long Gender { get; set; }
        /// <summary>
        /// Get or set the Mobile Number of professional
        /// </summary>
        public int MobileNumber { get; set; }
        /// <summary>
        /// Get or set the alternate contact number of professional
        /// </summary>
        public int ContactNumber { get; set; }
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
