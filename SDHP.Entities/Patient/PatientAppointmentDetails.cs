using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Patient
{
   public class PatientAppointmentDetails:IEntityBase
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
        /// Get or Set property to hold Patient Observation details
        /// </summary>
        public string Observation { get; set; }
        /// <summary>
        /// Get or Set property to hold Patient  disease indication
        /// </summary>
        public string Indication { get; set; }
        /// <summary>
        /// Get or Set property to hold Patient Examination Date/Time
        /// </summary>
        public DateTime ExamDate { get; set; }
        /// <summary>
        /// Get or Set property to hold Patient Status
        /// </summary>
        public bool status { get; set; }
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
