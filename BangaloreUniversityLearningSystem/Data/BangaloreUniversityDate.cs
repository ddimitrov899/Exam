using System;
using BangaloreUniversityLearningSystem.Data;
using Interfaces;
using BangaloreUniversityLearningSystem.data;

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
