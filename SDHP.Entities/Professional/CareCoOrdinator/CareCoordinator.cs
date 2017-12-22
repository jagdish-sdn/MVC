using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Professional.CareCoOrdinator
{
    public class CareCoordinator : IEntityBase
    { 
        [Key]
        /// <summary>
        /// Get or Set property to hold ID  
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Get or Set the Professional ID (GUID)
        /// </summary>
        public string ProfessionalID { get; set; }

        public Guid RecordID { get; set; }
        /// <summary>
        /// Get or Set the Disease Name
        /// </summary>      
        public string First_name { get; set; }
        /// <summary>
        /// Get or Set HowLong Disease
        /// </summary>
        public string Last_name { get; set; }
        /// <summary>
        /// Get or Set the How Ended Disease
        /// </summary>
        public string SSN { get; set; }
        /// <summary>
        /// Get or Set the Drug 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Get or Set the Relationship1 with patient
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Get or Set the first Relative Name of patient
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Get or Set the first 
        /// Relationship with patient
        /// </summary>
        public string Zip_code { get; set; }
        /// <summary>
        /// Get or Set the second RelativeName of patient
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Get or set the Professioanal RoleID(From Aspnet Role)
        /// </summary>
        public string CareCoordinator_npi_no { get; set; }
        /// <summary>
        /// Get or Set the second RelativeName of patient
        /// </summary>
        public string Mobile_no { get; set; }
        /// <summary>
        /// Get or set the Professioanal RoleID(From Aspnet Role)
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Get or set the record creation date time
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Get or set the modified ID
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Get or set the date time of modification
        /// </summary>
        public DateTime? Modifiedon { get; set; }

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
