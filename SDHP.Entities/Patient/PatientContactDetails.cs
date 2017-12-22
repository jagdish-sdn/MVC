using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Patient
{
  public  class PatientContactDetails:IEntityBase
    {
        [Key]
        /// <summary>
        /// Get or Set property to hold ID  
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Get or Set property to hold Patient ID (Foreign key)  
        /// </summary>
        public long PatientID { get; set; }
        /// <summary>
        /// Get or Set property to hold the Patient Residential Contact Number
        /// </summary>
        public int ResidenceContactNumber { get; set; }
        /// <summary>
        /// Get or Set property to hold the Patient Work Conatct Number
        /// </summary>
        public int WorkContactNumber { get; set; }
        /// <summary>
        /// Get or Set property to hold Personal Mobile number
        /// </summary>
        public int MobileNumber { get; set; }
        /// <summary>
        /// Get or Set property to hold the Email ID of patient
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///  Get or set property to hold patient Social security number
        /// </summary>
        public long SocialSecurityNumber { get; set; }
        /// <summary>
        /// Get or Set property to hold Contributory Provident Fund(CPF) of patient
        /// </summary>
        public string CPF { get; set; }
        /// <summary>
        /// Gets or sets flag to identify the patient is deleted or not. 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        ///  Gets or sets the patient has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID { get; set; }
        /// <summary>
        /// Gets or sets the patient has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
      
    }
}
