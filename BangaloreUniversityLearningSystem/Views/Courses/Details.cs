using System;
using System.Linq;
using System.Text;
using BangaloreUniversityLearningSystem.Infrastructure;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem.Views.Courses
{
    public class Details : View
    {
        public Details(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendLine(course.Name);
            if (!course.Lectures.Any())
            {
                viewResult.AppendLine("No lectures");
            }
            else
            {
                var lectureNames = course.Lectures.Select(l => "- " + l.Name);
                viewResult.AppendLine(string.Join(Environment.NewLine, lectureNames));
            }
        }
    }
}

