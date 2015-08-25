// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BangaloreUniversityLearningSystemUnitTest.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace BangaloreUniversityLearningSystemUnitTest
{
    using System;

    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Utilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BangaloreUniversityLearningSystemUnitTest
    {
        const string Username = "newUsername";
        const string Password = "paSword123";
         Role Role = Role.Student;

        /// <summary>Test RegisterUser Message Succеss</summary>
        [TestMethod]
        public void TestRegisterUser()
        {
            var system = new UsersController(new BangaloreUniversityDate(), new User(Username, Password, this.Role));
            system.Logout();
            var result = system.Register(Username, Password, Password, this.Role.ToString());

            Assert.AreEqual("User newUsername registered successfully.", result.Display());
        }

        /// <summary>Test Login Message Succеss</summary>
        [TestMethod]
        public void TestLoginUser()
        {
            var system = new UsersController(new BangaloreUniversityDate(), new User(Username, Password, this.Role));
            system.Logout();
            system.Register(Username, Password, Password, this.Role.ToString());
            var result = system.Login(Username, Password);

            Assert.AreEqual("User newUsername logged in successfully.", result.Display());
        }

        /// <summary>Test Logout Message Succеss</summary>
        [TestMethod]
        public void TestLogoutUser()
        {
            var system = new UsersController(new BangaloreUniversityDate(), new User(Username, Password, this.Role));
            system.Logout();
            system.Register(Username, Password, Password, this.Role.ToString());
            system.Login(Username, Password);
            var result = system.Logout();

            Assert.AreEqual("User newUsername logged out successfully.", result.Display());
        }

        /// <summary>Test Logout unlogin expect error message</summary>
        /// <exception cref="AssertFailedException">Always thrown.</exception>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), noExceptionMessage: "There is no currently logged in user.")]
        public void TestLogoutUserUnLogin()
        {
            var system = new UsersController(new BangaloreUniversityDate(), new User(Username, Password, this.Role));
            system.Logout();
            system.Register(Username, Password, Password, this.Role.ToString());
            var result = system.Logout();

            Assert.AreEqual(new ArgumentException("There is no currently logged in user.").InnerException.Message, result.Display());
        }

        /// <summary>Test create cource expect successes masage</summary>
         [TestMethod]
         public void TestAddCourse()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username,Password, Role.Lecturer));
            var result = system.Create("Advanced C#");
            

            Assert.AreEqual("Course Advanced C# created successfully.", result.Display());
        }
    }
}
