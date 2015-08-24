using System;

namespace BangaloreUniversityLearningSystem.Utilities
{
    public class Lecture
    {
        private string _name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value == null || value.Length < 3)
                    throw new ArgumentException(string.Format("The lecture name must be at least 3 symbols long."));
                this._name = value;
            }
        }
    }
}