namespace BangaloreUniversity.Views.Courses
{
    using System.Text;
    using BangaloreUniversity.Infrastructure;
    using BangaloreUniversity.Models;

    public class AddLecture : View
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
}