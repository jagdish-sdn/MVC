using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.CommonEntities
{
   public class _StateLookup:IEntityBase
    {

        public _StateLookup()
        {
            this.districtLookup = new HashSet<_DistrictLookup>();
        }
        [Key]
        /// <summary>
        /// Gets or sets property to hold the city ID.
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets property to hold the country ID of state.
        /// </summary>
        //[ForeignKey("_CountryLookup")]
        public long CountryID { get; set; }     
        //public virtual _CountryLookup _CountryLookup { get; set; }
        /// <summary>
        /// Gets or sets property to hold the state name.
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// Gets or sets property to hide the state or note.
        /// </summary>
        public bool Hide { get; set; }
        /// <summary>
        /// Gets or sets flag to identify the Country is deleted or not. 
        /// </summary>
        public bool? IsDeleted
        {

            get;set;
        }


        /// <summary>
        ///  Gets or sets the Country has been deleted by which user.
        /// </summary>
        public string IsDeletedByUserID { get; set; }

        /// <summary>
        /// Gets or sets the Country has been deleted by which user.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
        //[ForeignKey("StateID")]
        public virtual ICollection<_DistrictLookup> districtLookup { get; set; }
    }
}
