namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Interfaces;
    using Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return this.View(Data.Courses.GetAll()
                .OrderBy(course => course.Name)
                .ThenByDescending(course => course.Students.Count));
        }

        public IView Details(int courseId)
        {
            // TODO: Implement me
            var details = this.View(Data.Courses.Get(courseId));
            if (!this.HasCurrentUser)
            {
                const string Message = "There is no currently logged in user.";
                throw new ArgumentException(Message);
            }
            return details;
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var coursesId = Data.Courses.Get(courseId);
            if (coursesId == null)
            {
                string message = string.Format("There is no course with ID {0}.", courseId);
                throw new ArgumentException(message);
            }

            if (this.User.Courses.Contains(coursesId))
            {
                const string Message = "You are already enrolled in this course.";
                throw new ArgumentException(Message);
            }

            coursesId.AddStudent(this.User);
            return this.View(coursesId);
        }

        public Course CourseGetter(int courseId)
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
                const string Message = "There is no currently logged in user.";
                throw new ArgumentException(Message);
            }

            if (!this.User.IsInRole(Role.Lecturer) && this.User.IsInRole(Role.Student))
            {
                const string Message = "The current user is not authorized to perform this operation.";
                throw new DivideByZeroException(Message);
            }

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                const string Message = "There is no currently logged in user.";
                throw new ArgumentException(Message);
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                const string Message = "The current user is not authorized to perform this operation.";
                throw new DivideByZeroException(Message);
            }

            Course course = this.CourseGetter(courseId);
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }
    }
}