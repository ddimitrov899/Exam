using BangaloreUniversityLearningSystem.Utilities;
using System;
using System.Linq;
using BangaloreUniversityLearningSystem.Interfaces;

namespace BangaloreUniversityLearningSystem.Controllers
{
    internal class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            Data = data;
            User = user;
        }

        public IView All()
        {
            return View(Data.Courses.GetAll()
                        .OrderBy(course => course.Name)
                        .ThenByDescending(course => course.Students.Count));
        }

        public IView Details(int courseId)
        {
            // TODO: Implement me
            return View(Data.Courses.Get(courseId));
        }

        public IView Enroll(int id)
        {
            EnsureAuthorization(Role.Student, Role.Lecturer);
            var coursesId = Data.Courses.Get(id);
            if (coursesId == null)
            {
                string message = string.Format("There is no course with ID {0}.", id);
                throw new ArgumentException(message);
            }

            if (this.User.Courses.Contains(coursesId))
            {
                const string message = "You are already enrolled in this course.";
                throw new ArgumentException(message);
            }

            coursesId.AddStudent(this.User);
            return View(coursesId);
        }

        private Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                string message = string.Format("There is no course with ID {0}.", courseId);
                throw new ArgumentException(message);
            }
            return course;
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                const string message = "There is no currently logged in user.";
                throw new ArgumentException(message);
            }

            if (this.User.IsInRole(Role.Lecturer))
            {
                const string message = "The current user is not authorized to perform this operation.";
                throw new DivideByZeroException(message);
            }

            var course = new Course(name);
            Data.Courses.Add(course);
            return View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                const string message = "There is no currently logged in user.";
                throw new ArgumentException(message);
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                const string message = "The current user is not authorized to perform this operation.";
                throw new DivideByZeroException(message);
            }

            Course course = CourseGetter(courseId);
            course.AddLecture(new Lecture("lectureName"));
            return View(course);
        }
    }
}