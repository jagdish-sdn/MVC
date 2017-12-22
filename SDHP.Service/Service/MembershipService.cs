//using HomeHealthCare.Entities;
//using HomeHealthCare.Repositories;
//using HomeHealthCare.Repositories.Extension;
//using HomeHealthCare.Repositories.Infrastructure;
using HomeHealthCare.Services.Abstract;
//using HomeHealthCare.Services.EmailConfiguration;
//using HomeHealthCare.Services.Utilities;
//using HomeHealthCare.ViewModel;
using SDHP.Entities;
using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SDHP.Service.Service.Utilities;
using System.Data;
using System.Web.Security;

namespace HomeHealthCare.Services
{
    public class MembershipService 
    {
        #region Variables
        private readonly IEntityBaseRepository<User> _userRepository;
        //private readonly IEntityBaseRepository<Role> _roleRepository;
        private readonly IEntityBaseRepository<UserRole> _userRoleRepository;
        //private readonly IEntityBaseRepository<ForgotPasswordLog> _forgotPasswordLogRepository;
        //private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public MembershipService(IEntityBaseRepository<User> userRepository,
        IEntityBaseRepository<UserRole> userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            // _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            //   _forgotPasswordLogRepository = forgotPasswordLogRepository;
            //  _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }


        //public MembershipContext ValidateUser(string username, string password)
        //{
        //    var membershipCtx = new MembershipContext();

        //    var user = _userRepository.GetSingleByUsername(username);
        //    if (user != null && isUserValid(user, password))
        //    {
        //        var userRoles = GetUserRoles(user.Username);
        //        membershipCtx.User = user;

        //        var identity = new GenericIdentity(user.Username);
        //        membershipCtx.Principal = new GenericPrincipal(
        //            identity,
        //            userRoles.Select(x => x.Name).ToArray());
        //    }

        //    return membershipCtx;
        //}
        //public List<Roles> GetUserRoles(string username)
        //{
        //    List<Role> _result = new List<Role>();

        //    var existingUser = _userRepository.GetSingleByUsername(username);

        //    if (existingUser != null)
        //    {
        //        foreach (var userRole in existingUser.UserRoles)
        //        {
        //            _result.Add(userRole.Role);
        //        }
        //    }

        //    return _result.Distinct().ToList();
        //}
        //public User GetUser(int userId)
        //{
        //    return _userRepository.GetSingle(userId);
        //}
        //public User CreateUser(string username, string email, string password, int[] roles, long userId)
        //{
        //    var existingUser = _userRepository.GetSingleByUsernameorEmail(username, email);

        //    if (existingUser != null)
        //    {
        //        if (existingUser.Username == username)
        //            throw new Exception("Username is already in use");
        //        else
        //            throw new Exception("Email is already in use");

        //    }

        //    var passwordSalt = _encryptionService.CreateSalt();
        //    var islockedVal = roles[0] == 2 ? (true) : (false);
        //    var user = new User()
        //    {
        //        UserID = userId,
        //        Username = username,
        //        Salt = passwordSalt,
        //        Email = email,
        //        IsLocked = islockedVal,
        //        HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
        //        DateCreated = DateTime.Now
        //    };

        //    _userRepository.Add(user);

        //    _unitOfWork.Commit();

        //    //var EmailBody = roles[0] == 2 ? (SMTPProvider.EmailBodyOperatorRegistered.Replace("##username##", user.Username).Replace("##password##", password)) : (SMTPProvider.EmailBodyUserRegistered.Replace("##username##", user.Username).Replace("##password##", password));

        //    // _commonService.SendMails(user.Email, SMTPProvider.WelcomeSubject, EmailBody);

        //    //if (roles != null || roles.Length > 0)
        //    //{
        //    //    foreach (var role in roles)
        //    //    {
        //    //        addUserToRole(user, role);
        //    //    }
        //    //}

        //    _unitOfWork.Commit();

        //    return user;
        //}

        //public ResponseViewModel ResetPassword(UserViewModel userViewModel)
        //{
        //    var responseViewModel = new ResponseViewModel();
        //    //var existingUser = _userRepository.GetSingleByUsername(userViewModel.Username);
        //    var existingUser = _forgotPasswordLogRepository.FindBy(f => f.Guid == userViewModel.Guid).FirstOrDefault();
        //    if (existingUser == null)
        //    {
        //        responseViewModel.responseData = userViewModel;
        //        responseViewModel.status = 0;
        //        responseViewModel.message = Constants.InvalidUser;
        //    }
        //    else
        //    {
        //        if (existingUser.User.Username != userViewModel.Username)
        //        {
        //            responseViewModel.responseData = userViewModel;
        //            responseViewModel.status = 0;
        //            responseViewModel.message = Constants.GenerateLink;
        //        }
        //        else
        //        {
        //            var passwordSalt = _encryptionService.CreateSalt();

        //            var user = new User()
        //            {
        //                ID = existingUser.User.ID,
        //                Username = userViewModel.Username,
        //                Salt = passwordSalt,
        //                Email = existingUser.User.Email,
        //                IsDeleted = false,
        //                IsLocked = existingUser.User.IsLocked,
        //                HashedPassword = _encryptionService.EncryptPassword(userViewModel.HashedPassword, passwordSalt),
        //                DateCreated = existingUser.User.DateCreated
        //            };
        //            userViewModel.Email = user.Email;
        //            _userRepository.Edit(existingUser.User, user);

        //            _forgotPasswordLogRepository.SoftDelete(existingUser);
        //            _unitOfWork.Commit();

        //            responseViewModel.responseData = userViewModel;
        //            responseViewModel.status = 1;
        //            responseViewModel.message = Constants.Success;
        //        }
        //    }
        //    return responseViewModel;
        //}
        //private void addUserToRole(User user, long roleId)
        //{
        //    var role = _roleRepository.GetSingle(roleId);
        //    if (role == null)
        //        throw new ApplicationException("Role doesn't exist.");

        //    var userRole = new UserRole()
        //    {
        //        RoleId = role.ID,
        //        UserId = user.ID
        //    };
        //    _userRoleRepository.Add(userRole);
        //}

        //private bool isPasswordValid(User user, string password)
        //{
        //    return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        //}

        //private bool isUserValid(User user, string password)
        //{
        //    if (isPasswordValid(user, password))
        //    {
        //        return !user.IsLocked;
        //    }

        //    return false;
        //}
    }
}
