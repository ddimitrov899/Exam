namespace BangaloreUniversity.Controllers
{
    using System;
    using System.Linq;
    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Models;
    using BangaloreUniversity.Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            var getAll = this.View(Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
            return getAll;
        }

        public IView Details(int courseId)
        {
            // TODO: Implement me
            this.EnsureAuthorization(Role.Lecturer, Role.Student);
            var course = this.GetCurenCourses(courseId);

            if (!this.User.Courses.Contains(course))
            {
                throw new AggregateException("You are not enrolled in this course.");
            }

            var getAll = this.View(course);

            return getAll;
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCurenCourses(courseId);

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.User);
            return this.View(course);
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            var course = this.GetCurenCourses(courseId);
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }

        private Course GetCurenCourses(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }
    }
}
