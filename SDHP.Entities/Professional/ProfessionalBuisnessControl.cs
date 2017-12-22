using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Professional
{
  public  class ProfessionalBuisnessControl:IEntityBase
    {
        [Key]
        /// <summary>
        /// Get or Set property to hold ID  
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Get or set property to hold ProfessionalID(ForeignKey)
        /// </summary>
        public long ProfessionalD { get; set; }
        /// <summary>
        /// Get or set the PatientID
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// Get or set property to hold PatientName
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// Get or set the AppointmentDate
        /// </summary>
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// Get or set property to hold AppointmentTime
        /// </summary>
        public TimeSpan AppointmentTime{get;set;}
        /// <summary>
        /// Get or set property to hold Buisness Control Action
        /// </summary>
        public string ProfessionalAction { get; set; }
        /// <summary>
        /// Get or set property to hold Procedure type(For procedure-type Action)
        /// </summary>
        public long ProcedureType { get; set; }
        /// <summary>
        /// Get or set property to hold ActionFeedback
        /// </summary>
        public long ActionFeedback { get; set; }
        /// <summary>
        /// Get or set property to hold Cancellation Details(For Cancellation Details Action type)
        /// </summary>
        public string CancellationDetails { get; set; }
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
