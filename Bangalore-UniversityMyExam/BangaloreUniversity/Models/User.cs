namespace BangaloreUniversity.Models
{
    using System;
    using System.Collections.Generic;
    using BangaloreUniversity.Utilities;

    public class User
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.PasswordHash = password;
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
                if (string.IsNullOrEmpty(value))
                {
                    string message = "The username cannot be null or empty.";
                    throw new ArgumentException(message);
                }

                if (value.Length < 5)
                {
                    string message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return HashUtilities.HashPassword(this.passwordHash);
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    string message = "The password cannot be null or empty.";
                    throw new ArgumentException(message);
                }

                if (value.Length < 6)
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