using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities
{
    public class UserRole : IEntityBase
    {
        [Key]
        public long ID { get; set; }
        public long IdentityUserID { get; set; }
        public long RoleId { get; set; }
        //Create Details
        public Nullable<int> CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        //End
        //Modify Details
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        //End
        public Nullable<bool> IsDeleted { get; set; }
        public string IsDeletedByUserID { get; set; }
        public Nullable<DateTime> DeletionDate { get; set; }
    }
}
