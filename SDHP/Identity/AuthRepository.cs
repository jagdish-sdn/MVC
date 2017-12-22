using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SDHP.Common;
using SDHP.Entities;
using SDHP.Models;
using SDHP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SDHP.Identity
{
    public class AuthRepository : IDisposable
    {
        private ApplicationContext _ctx;

        private UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _ctx = new ApplicationContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            ApplicationUser user = new ApplicationUser

            {
                UserName = userModel.UserName,
                Email=userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<ApplicationUser> FindUser(string UserName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(UserName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}