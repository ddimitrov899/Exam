using System.Text;
using BangaloreUniversityLearningSystem.Infrastructure;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem.Views.Users
{
    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }
        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(string.Format("User {0} logged out successfully."), ((User)this.Model).Username)
                .AppendLine();
        }
    }
}