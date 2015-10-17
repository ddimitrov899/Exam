namespace BangaloreUniversity.Views.Users
{
    using System.Text;
    using BangaloreUniversity.Infrastructure;
    using BangaloreUniversity.Models;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", (this.Model as User).Username).AppendLine();
        }
    }
}