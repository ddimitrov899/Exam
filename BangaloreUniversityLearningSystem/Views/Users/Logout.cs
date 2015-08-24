namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Infrastructure;
    using Utilities;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }
        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(string.Format("User {0} logged out successfully."), (this.Model as User).Username).AppendLine();
        }
    }
}