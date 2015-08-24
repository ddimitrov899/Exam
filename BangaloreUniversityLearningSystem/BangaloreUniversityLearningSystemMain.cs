namespace BangaloreUniversityLearningSystem
{
    using BangaloreUniversityLearningSystem.UI;

    using Core;

    public class BangaloreUniversityLearningSystemMain
    {
        public static void Main(string[] args)
        {
            var engen = new BangaloreUniversityEngine();
            engen.Run(new UserInterface());
        }
    }
}