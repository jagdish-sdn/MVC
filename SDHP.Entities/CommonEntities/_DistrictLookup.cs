using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.CommonEntities
{
    public class _DistrictLookup : IEntityBase
    {
        public _DistrictLookup()
        {
            this._cityLookup = new HashSet<_CityLookup>();
        }
        [Key]
        /// <summary>
        /// Gets or sets property to hold the District ID.
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Get or set for state ID
        /// </summary>
        public long StateID { get; set; }
        /// <summary>
        /// Get or set for District name
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// Get or set to show state is hide or not
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
        ///  Gets or sets the District has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID { get; set; }

        /// <summary>
        /// Gets or sets the District has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
        public ICollection<_CityLookup> _cityLookup { get; set; }

    }
}
