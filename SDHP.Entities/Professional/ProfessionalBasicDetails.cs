using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Professional
{
   public class ProfessionalBasicDetails:IEntityBase
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
       /// <summary>
       /// Get or Set the DesignationID (Foreign key With LookUp table)
       /// </summary>      
        public long Designation { get; set; }
        /// <summary>
        /// Get or Set the Professional SpecializationID (Foreign key With LookUp table)
        /// </summary>
        public long Specialization { get; set; }
        /// <summary>
        /// Get or Set the Experiance of Professional
        /// </summary>
        public string Experiance { get; set; }
        /// <summary>
        /// Get or Set the Social Security Number of Professioanl
        /// </summary>
        public long SocialSecurityNumber { get; set; }
        /// <summary>
        /// Get or Set the ProfessioanlShift
        /// </summary>
        public long ProfessionalShift { get; set; }
        /// <summary>
        /// Get or Set the profesiional Weekly Off
        /// </summary>
        public string WeeklyOff { get; set; }
        /// <summary>
        /// Get or set the Professioanal RoleID(From Aspnet Role)
        /// </summary>
        public string ProfessionalRoleID { get; set; }

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

        [ForeignKey("ProfessionalID")]
        public virtual ICollection<ProfessionalContactDetails> ContactDetails { get; set; }

        [ForeignKey("ProfessionalID")]
        public virtual ICollection<ProfessionalAddressDetails> AddressDetails { get; set; }

        [ForeignKey("ProfessionalID")]
        public virtual ICollection<ProfessionalJoiningDetails> JoiningDetails { get; set; }

        [ForeignKey("ProfessionalID")]
        public virtual ICollection<ProfessionalProfileImages> ProfileImage { get; set; }


    }
}
