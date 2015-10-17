namespace BangaloreUniversity.Interfaces
{
    using BangaloreUniversity.Data;
    using BangaloreUniversity.Models;

    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}