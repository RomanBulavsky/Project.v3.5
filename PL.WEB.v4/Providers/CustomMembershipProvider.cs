using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;

namespace PL.WEB.v4.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));

        public override bool ValidateUser(string email, string password)
        {
            bool isValid = true;
            try
            {
                var user = UserService.GetAll().FirstOrDefault(e => e.Email == email);
                if (user?.Email != email || user?.Password != password)
                    isValid = false;
            }
            catch
            {
                isValid = false;
            }
            
            return isValid;
        }

        public MembershipUser CreateUser(string login, string email, string password,
            out MembershipCreateStatus createStatus)
        {
            MembershipUser membershipUser = GetUser(email, false);
            createStatus = MembershipCreateStatus.DuplicateEmail; ///
            if (membershipUser == null)
            {
                try
                {
                    UserService.Create(new BllUser()
                    {
                        Email = email,
                        Login = login,
                        Password = password//TODO:Crypto.HashPassword(password);
                    });           
                    membershipUser = GetUser(email, false);
                    createStatus = MembershipCreateStatus.Success; ///TODO: Provider
                    return membershipUser;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            if (email.IsEmpty()) return null;
            var users = UserService.GetAll();
            var user = users.FirstOrDefault(e => e.Email == email);
            if (user == null) return null;
            MembershipUser memberUser = new MembershipUser("CustomMembershipProvider", user.Login, null, user.Email,
                null, null,
                false, false, user.CreationDate, DateTime.Now, DateTime.Today, user.CreationDate, DateTime.MinValue);
            return memberUser;
        }

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey,
            out MembershipCreateStatus status)
        {
            return CreateUser(username, email, password, out status);
        }

        #region stabs

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
            string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}