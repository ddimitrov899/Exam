namespace BangaloreUniversityLearningSystem.Utilities
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        private string username;
        private string passwordHash;
        private string password;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.PasswordHash = HashUtilities.HashPassword(password);
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    string message = "The password must be at least 6 symbols long.";
                    throw new ArgumentException(message);
                }
                password = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    string message = "The password must be at least 6 symbols long.";
                    throw new ArgumentException(message);
                }

                this.passwordHash = value;
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}