using System;
using System.Collections.Generic;

namespace BangaloreUniversityLearningSystem.Utilities
{
    public class Course
    {
        private string _name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<Lecture>();
        }

        public string Name
        {
            get
            {
                return this._name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string message = "The course name must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this._name = value;
            }
        }

        public IList<Lecture> Lectures { get; set; }

        public IList<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}