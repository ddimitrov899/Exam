namespace BangaloreUniversityLearningSystem.Interfaces
{
    using Data;
    using Utilities;

    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}