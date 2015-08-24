using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }
        IRepository<Course> Courses { get; }
    }
}