using SDHP.Entities;
using SDHP.Service.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHealthCare.Services.Abstract
{
    public interface IMembershipService
    {
        /// <summary>
        //
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        MembershipContext ValidateUser(string username, string password);
        /// <summary>
        //
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        User CreateUser(string username, string email, string password, int[] roles, long userId);
        /// <summary>
        //
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUser(int userId);
        /// <summary>
        //
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        //List<Role> GetUserRoles(string username);
        /// <summary>
        //
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        //ResponseViewModel ResetPassword(UserViewModel userViewModel);

    }
}
