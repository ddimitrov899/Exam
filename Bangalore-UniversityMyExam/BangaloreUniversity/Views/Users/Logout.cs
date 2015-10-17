namespace BangaloreUniversity.Views.Users
{
    using System.Text;
    using BangaloreUniversity.Infrastructure;
    using BangaloreUniversity.Models;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged out successfully.", (this.Model as User).Username).AppendLine();
        }
    }
}