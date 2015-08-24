using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem
{
    public abstract class Controller
    {
        public User User { get; set; }

        public bool HasCurrentUser => User != null;

        protected IBangaloreUniversityDate Data { get; set; }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".", StringComparison.Ordinal);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("Controller", "");
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                const string message = "There is no currently logged in user.";
                throw new ArgumentException(message);
            }

            if (Data.Users.GetAll().Any(u => !roles.Any(role => this.User.IsInRole(role))))
            {
                const string message = "The current user is not authorized to perform this operation.";
                throw new DivideByZeroException(message);
            }
        }
    }
}