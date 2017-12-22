using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Masters
{
    public class CategoryType : IEntityBase
    {
        [Key]
        public long ID { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string IsDeletedByUserID { get; set; }
        public Nullable<DateTime> DeletionDate { get; set; }
    }
}
