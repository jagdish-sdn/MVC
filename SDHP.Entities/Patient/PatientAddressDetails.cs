using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Patient
{
   public class PatientAddressDetails:IEntityBase
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
        /// / Get or Set property to hold Patient Address Line 1
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        ///  Get or Set property to hold Patient Address Line 2
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        ///  Get or Set property to hold Patient Country(from Lookup)
        /// </summary>
        public long Country { get; set; }
        /// <summary>
        /// / Get or Set property to hold Patient State(from lookup)
        /// </summary>
        public long State { get; set; }
        /// <summary>
        /// Get or Set property to hold Patient District(from Lookup)
        /// </summary>
        public long District { get; set; }
        /// <summary>
        ///Get or Set property to hold Patient City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Get or set property to hold patient ZipCode
        /// </summary>
        public long ZipCode { get; set; }
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
