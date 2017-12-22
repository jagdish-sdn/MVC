using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Patient
{
   public class PatientDocumentsUploadDetails:IEntityBase
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
        /// Get or set the Original File Name
        /// </summary>
        public string OriginalFileName { get; set; }
        /// <summary>
        /// Get or set the Changed File Name(GUID)
        /// </summary>
        public string ChangedFileName { get; set; }
        /// <summary>
        /// Get or set the File Path where it is exactly located
        /// </summary>
        public string FilePath { get; set; }
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
