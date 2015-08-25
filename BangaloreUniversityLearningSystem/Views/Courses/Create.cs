namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;
    using Infrastructure;
    using Utilities;

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