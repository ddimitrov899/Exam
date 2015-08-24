namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public class UsersRepository : Repository<User>
    {
        public UsersRepository()
        {
            UsersByUsername = new Dictionary<string, User>();
        }

        public Dictionary<string, User> UsersByUsername { get; }

        public User GetByUsername(string username)
        {
            return this.Items.FirstOrDefault(u => u.Username == username);
        }
    }
}
