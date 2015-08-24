using System;
using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.data;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Utilities;

namespace Data
{
    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public UsersRepository Users { get; internal set; }
        public IRepository<Course> Courses { get;  protected set; }

        public BangaloreUniversityDate()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }
    }
}
