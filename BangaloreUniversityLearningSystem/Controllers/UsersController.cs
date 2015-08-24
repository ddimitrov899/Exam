using System;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem.Controllers
{
    class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDate data, User user)
        {
            Data = data;
            User = user;
        }
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                const string message = "The provided passwords do not match.";
                throw new ArgumentException(message);
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
            return View(user);
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
                const string message = "The provided password is wrong.";
                throw new ArgumentException(message);
            }
            this.User = existingUser;
            return View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                const string message = "There is no currently logged in user.";
                throw new ArgumentException(message);
            }

            if (!this.User.IsInRole(Role.Lecturer) && !this.User.IsInRole(Role.Student))
            {
                const string message = "The current user is not authorized to perform this operation.";
                throw new DivideByZeroException(message);
            }

            var user = this.User;
            this.User = null;
            return View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                const string message = "There is already a logged in user.";
                throw new ArgumentException(message);
            }
        }
    }
}