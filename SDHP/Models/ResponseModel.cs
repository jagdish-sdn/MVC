using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDHP.Models
{
    public sealed class ResponseModel<T>
    {
        private T _t;

        /// <summary>
        /// Gets or sets property to hold the response data.
        /// </summary>
        public T Response
        {
            get { return _t; }
            set { _t = value; }
        }
        private bool? _IsError = null;
        /// <summary>
        /// Gets the true if any error occurs else will get value false.
        /// </summary>
        public bool IsError
        {
            get
            {
                if (_IsError == null)
                {
                    _IsError = _t == null && !string.IsNullOrEmpty(Message);
                }
                return _IsError.Value;
            }
        }
        public void ForceToSetError() { _IsError = true; }
        /// <summary>
        /// Gets or sets the complete records.
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Gets or sets property to hold the error message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets to hold the multiple error messages.
        /// </summary>
        public List<string> Messages { get; set; }
        /// <summary>
        /// Gets or sets property to hold the response code.
        /// </summary>
        public int ResponseCode { get; set; }
        /// <summary>
        /// Gets or sets property to hold the response description.
        /// </summary>
        public string ResponseDescription { get; set; }
        /// <summary>
        /// Gets or sets property to hold the sub status code of response.
        /// </summary>
        public int SubStatusCode { get; set; }

    }
}