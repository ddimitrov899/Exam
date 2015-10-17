namespace BangaloreUniversity.Views.Courses
{
    using System.Text;
    using BangaloreUniversity.Infrastructure;
    using BangaloreUniversity.Models;

    public class Enroll : View
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Student successfully enrolled in course {0}.", course.Name).AppendLine();
        }
    }
}