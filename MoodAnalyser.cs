using System;

namespace MoodAnalyserProblem
{
   public class MoodAnalyser
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Problem");
            Console.WriteLine("enter your mood");
            string message= Console.ReadLine();
            new MoodAnalyser().AnalyseMood(message);
        }
        public string AnalyseMood(string message)
        {
            if (message.Contains("sad"))
                return "SAD";
            else
                return "HAPPY";
        }



    }
}
