using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.CommonEntities
{
   public class _CityLookup:IEntityBase
    {
       
        [Key]
        /// <summary>
        /// Gets or sets property to hold the District ID.
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets property to hold the District ID of city.
        /// </summary>
        public long DistrictID { get; set; }
        /// <summary>
        /// Gets or sets property to hold the city name.
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// Gets or sets property to hide the city or note.
        /// </summary>
        public bool Hide { get; set; }
        /// <summary>
        /// Get or set property to show record is deleted or not
        /// </summary>
        public bool? IsDeleted
        {

            get; set;
        }
        /// <summary>
        ///  Gets or sets the City has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID { get; set; }

        /// <summary>
        /// Gets or sets the City has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
       
    }
}
