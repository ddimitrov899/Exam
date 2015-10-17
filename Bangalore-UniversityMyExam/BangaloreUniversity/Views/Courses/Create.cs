namespace BangaloreUniversity.Views.Courses
{
    using System.Text;
    using BangaloreUniversity.Infrastructure;
    using BangaloreUniversity.Models;

    public class Create : View
    {
        public Create(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}