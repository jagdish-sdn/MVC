using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.Masters
{
    public class Category : IEntityBase
    {
        [Key]
        public long ID { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("CategoryType")]
        public long CategoryTypeID { get; set; }
        public virtual CategoryType CategoryType { get; set; }
        public long ParentCategoryID { get; set; }
        public string Color { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string IsDeletedByUserID { get; set; }
        public Nullable<DateTime> DeletionDate { get; set; }
    }
}
