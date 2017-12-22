using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Entities.CommonEntities
{
    public class _CountryLookup : IEntityBase
    {
        public _CountryLookup()
        {
            this.statelookup = new HashSet<_StateLookup>();
        }

        [Key, Column(Order = 0)]
        /// <summary>
        /// Get or Set property to hold ID  
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets property to hold the country name.
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// Gets or sets property to hold the country code.
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Gets or sets property to hide the country or note.
        /// </summary>
        public bool Hide { get; set; }
        /// <summary>
        /// Gets or sets flag to identify the Country is deleted or not. 
        /// </summary>
        public bool? IsDeleted {

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

      
        public virtual ICollection<_StateLookup> statelookup { get; set; }


    }
}
