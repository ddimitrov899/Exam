using System.Collections.Generic;
using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IBangaloreUniversityDate
    {
        UsersRepository users { get; }
        IRepository<Course> courses { get; }
    }
    public interface Iइंजन
    {
        void रन();
    }
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
    }
    public interface IRoute
    {
        string _controllerName { get; }
        string _actionName { get; }
        IDictionary<string, string> _parameters { get; }
    }
    public interface IView
    {
        object Model { get; }
        string Display();
    }
}