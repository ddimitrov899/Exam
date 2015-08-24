namespace BangaloreUniversityLearningSystem.Utilities
{
    using System;
    using System.Collections.Generic;
    using utilities;

    public class User
    {
        private string _username;
        private string _passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.PasswordHash = HashUtilities.HashPassword(password);
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this._username;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this._username = value;
            }
        }

        public string PasswordHash
        {
            get { return this._passwordHash; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string message = "The password must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }
                this._passwordHash = value;
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}