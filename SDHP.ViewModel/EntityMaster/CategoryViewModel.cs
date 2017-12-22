using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.ViewModel.EntityMaster
{
    public class CategoryViewModel
    {
        public long ID { get; set; }
        public string CategoryName { get; set; }
        public long CategoryTypeID { get; set; }
        public long ParentCategoryID { get; set; }
        public string Color { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string IsDeletedByUserID { get; set; }
        public Nullable<DateTime> DeletionDate { get; set; }
    }
}
