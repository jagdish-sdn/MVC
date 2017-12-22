using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.ViewModel.EntityMaster
{
    public class CategoryTypeViewModel
    {
        public long ID { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string IsDeletedByUserID { get; set; }
        public Nullable<DateTime> DeletionDate { get; set; }
    }
}
