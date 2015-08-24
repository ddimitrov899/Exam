﻿namespace BangaloreUniversityLearningSystem.Data
{
    using Interfaces;
    using Utilities;

    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public UsersRepository Users { get; internal set; }
        public IRepository<Course> Courses { get; protected set; }

        public BangaloreUniversityDate()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }
    }
}
