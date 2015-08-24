namespace BangaloreUniversityLearningSystem.UI
{
    using System;

    using Interfaces;

    public class UserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params object[] arguments)
        {
            Console.WriteLine(format, arguments);
        }
    }
}