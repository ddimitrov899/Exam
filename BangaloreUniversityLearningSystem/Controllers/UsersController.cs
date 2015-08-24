namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using Interfaces;
    using Utilities;

    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                const string Message = "The provided passwords do not match.";
                throw new ArgumentException(Message);
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                string message = string.Format("A user with username {0} does not exist.", username);
                throw new ArgumentException(message);
            }

            if (existingUser.PasswordHash != HashUtilities.HashPassword(password))
            {
                const string Message = "The provided password is wrong.";
                throw new ArgumentException(Message);
            }

            this.User = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                const string Message = "There is no currently logged in user.";
                throw new ArgumentException(Message);
            }

            if (!this.User.IsInRole(Role.Lecturer) && !this.User.IsInRole(Role.Student))
            {
                const string Message = "The current user is not authorized to perform this operation.";
                throw new DivideByZeroException(Message);
            }

            var user = this.User;
            this.User = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                const string Message = "There is already a logged in user.";
                throw new ArgumentException(Message);
            }
        }
    }
}