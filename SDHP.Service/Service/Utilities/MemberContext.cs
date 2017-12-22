using SDHP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SDHP.Service.Service.Utilities
{
    public class MembershipContext
    {
            /// <summary>
            /// Gets or sets the principal.
            /// </summary>
            /// <value>The principal.</value>
            public IPrincipal Principal { get; set; }
            /// <summary>
            /// Gets or sets the user.
            /// </summary>
            /// <value>The user.</value>
            public User User { get; set; }

            /// <summary>
            /// Determines whether this instance is valid.
            /// </summary>
            /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
            public bool IsValid()
            {
                return Principal != null;
            }
    }
}
