using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Patient
{
   public class PatientBasicDetails:IEntityBase
    {
        [Key]
        /// <summary>
        /// Get or Set property to hold ID  
        /// </summary>
        public long ID { get; set; }
       
        /// <summary>
        /// Get or set property to hold PatientID(GUID)
        /// </summary>
        public string PatientID { get; set; }
      
        /// <summary>
        ///  Get or set property to hold patient First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        ///  Get or set property to hold patient Middle Name
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        ///  Get or set property to hold patient Last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        ///  Get or set property to hold patient Date of birth
        /// </summary>
        public DateTime DOB { get; set; }                  
        /// <summary>
        /// Gets or sets flag to identify the Patient is deleted or not. 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        ///  Gets or sets the Patient has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID { get; set; }
        /// <summary>
        /// Gets or sets the Patient has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
        [ForeignKey("PatientID")]
        public virtual ICollection<PatientContactDetails> ContactDetails { get; set; }

        [ForeignKey("PatientID")]
        public virtual ICollection<PatientAddressDetails> AddressDetails { get; set; }

        [ForeignKey("PatientID")]
        public virtual ICollection<PatientAppointmentDetails> JoiningDetails { get; set; }

        [ForeignKey("PatientID")]
        public virtual ICollection<PatientDocumentsUploadDetails> ProfileImage { get; set; }
    }
}
