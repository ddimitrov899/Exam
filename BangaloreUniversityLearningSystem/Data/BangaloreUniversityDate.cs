using System;
using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.data;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Utilities;

namespace Data
{
    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public UsersRepository users { get; internal set; }
        public IRepository<Course> courses { get;  protected set; }

        public BangaloreUniversityDate()
        {
            this.users = new UsersRepository();
            this.courses = new Repository<Course>();
        }
    }
}
