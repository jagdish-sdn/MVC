using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities
{
    public class User : IEntityBase
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public long ID { get; set; }
        public long IdentityUserID { get; set; }
        public string Username { get; set; }
        //public string Email { get; set; }
        public bool IsLocked { get; set; }
        [ForeignKey("IdentityUserID")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public string IsDeletedByUserID { get; set; }
        public Nullable<DateTime> DeletionDate { get; set; }
    }
}
