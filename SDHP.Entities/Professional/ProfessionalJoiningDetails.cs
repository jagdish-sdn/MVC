using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Professional
{
   public class ProfessionalJoiningDetails:IEntityBase
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
        /// Get or set the Joining Date of professional
        /// </summary>
        public DateTime JoiningDate { get; set; }
        /// <summary>
        /// Get or set the Confirmation Date of professional
        /// </summary>
        public DateTime ConfirmationDate { get; set; }
        /// <summary>
        /// Get or set the Staff Type of professional (Foreign key)
        /// </summary>
        public long StaffType { get; set; }        
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
