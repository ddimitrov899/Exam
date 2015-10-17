// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BangaloreUniversityLearningSystemUnitTest.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using BangaloreUniversity.Views.Courses;

namespace BangaloreUniversityLearningSystemUnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;
    using BangaloreUniversity.Controllers;
    using BangaloreUniversity.Core;
    using BangaloreUniversity.Data;
    using BangaloreUniversity.Infrastructure;
    using BangaloreUniversity.Models;
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
        

        /// <summary>Test create course expect successes masage</summary>
        [TestMethod]
        public void TestCreateCourse()
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
            var student = new UsersController(new BangaloreUniversityDate(), new User(Username, Password, Role));

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

            expect.Append("All courses:").AppendLine();
            expect.Append("Advanced C# (0 students)").AppendLine();
            expect.Append("Java Basic (0 students)");
            system.Create("Advanced C#");
            system.Create("Java Basic");
            var result = system.All();

            Assert.AreEqual(expect.ToString(), result.Display().Trim());
        }

        /// <summary>Test All method course but no cources expect error masage</summary>
        [TestMethod]
        public void TestAllMethodCourseNoCourse()
        {
            var system = new CoursesController(new BangaloreUniversityDate(), new User(Username, Password, Role.Lecturer));

            var result = system.All();

            Assert.AreEqual("No courses.", result.Display());
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
            system.Run();

        }
    }
}
