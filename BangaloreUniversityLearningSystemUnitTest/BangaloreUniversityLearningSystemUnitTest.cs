// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BangaloreUniversityLearningSystemUnitTest.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BangaloreUniversityLearningSystem.Core;
using BangaloreUniversityLearningSystem.Infrastructure;
using BangaloreUniversityLearningSystem.UI;

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

        /// <summary>Test create course expect successes masage</summary>
        [TestMethod]
        public void TestAddCourse()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username, Password, Role.Lecturer));
            var result = system.Create("Advanced C#");


            Assert.AreEqual("Course Advanced C# created successfully.", result.Display());
        }

        /// <summary>Test create course and add student expect successes masage</summary>
        [TestMethod]
        public void TestAddStudentInCourse()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username, Password, Role.Lecturer));
            var student = new UsersController(new BangaloreUniversityDate(), new User(Username, Password, this.Role));

            student.Logout();
            student.Register(Username, Password, Password, this.Role.ToString());
            student.Login(Username, Password);

            system.Create("Advanced C#");
            var result = system.Enroll(1);

            Assert.AreEqual("Student successfully enrolled in course Advanced C#.", result.Display());
        }

        /// <summary>Test All method course expect all course masage</summary>
        [TestMethod]
        public void TestAllMethodCourse()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username, Password, Role.Lecturer));
            var expect = new StringBuilder();

            expect.Append("All Courses:").AppendLine();
            expect.Append("Advanced C# (0 students)").AppendLine();
            expect.Append("Java Basic (0 students)");
            system.Create("Advanced C#");
            system.Create("Java Basic");
            var result = system.All();

            Assert.AreEqual(expect.ToString(), result.Display());
        }

        /// <summary>Test All method course but no cources expect error masage</summary>
        [TestMethod]
        public void TestAllMethodCourseNoCourse()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username, Password, Role.Lecturer));

            var result = system.All();

            Assert.AreEqual("No Courses.", result.Display());
        }

        /// <summary>Test Details method course but no cources expect error masage</summary>
        [TestMethod]
        public void TestDetailsMethodCourseNoLector()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username, Password, Role.Lecturer));
            var expect = new StringBuilder();

            expect.AppendLine("High-Quality Code");
            expect.Append("No lectures");
            system.Create("High-Quality Code");
            var result = system.Details(1);

            Assert.AreEqual(expect.ToString(), result.Display());
        }

        /// <summary>Test Details method course but no cources expect detail masage</summary>
        [TestMethod]
        public void TestDetailsMethod()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username, Password, Role.Lecturer));
            var expect = new StringBuilder();

            expect.AppendLine("High-Quality Code");
            expect.AppendLine("- Naming Identifiers");
            expect.AppendLine("- Comments in the Code");
            expect.Append("- High-Quality Classes");

            system.Create("High-Quality Code");
            system.AddLecture(1, "Naming Identifiers");
            system.AddLecture(1, "Comments in the Code");
            system.AddLecture(1, "High-Quality Classes");

            var result = system.Details(1);

            Assert.AreEqual(expect.ToString(), result.Display());
        }

        /// <summary>Test Details method course but no cources expect detail masage</summary>
        [TestMethod]
        public void TestRouteMethod()
        {
            var system = new Route("/Users/Register?username=firstStudent&password=firstPass&confirmPassword=firstPass&role=student");
            var result = system.ActionName;

            Assert.AreEqual("Register", result);
            result = system.ControllerName;

            Assert.AreEqual("UsersController", result);

        }
        /// <summary>Test Details method course but no cources expect detail masage</summary>
        [TestMethod]
        public void TestEngen()
        {
            var system = new BangaloreUniversityEngine();
            system.Run(new UserInterface());
            
        }
    }
}
