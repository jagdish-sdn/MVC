using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDHP.Models
{
    public class ResponseCodeModel
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        public string recordId { get; set; }
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Data
        /// </summary>
        public object Data { get; set; }

        public int TotalRecord { get; set; }


    }
}