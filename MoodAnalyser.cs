using System;

namespace MoodAnalyserProblem
{
   public class MoodAnalyser
    {
        public string message;
        //Refactor code to add constuctor
        public MoodAnalyser(string message)
        {
            this.message = message.ToLower();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Problem");
            new MoodAnalyser("i am in sad mood");
           
           
        }
        /// <summary>
        /// method to analyse mood
        /// </summary>
        /// <returns></returns>
        public string AnalyseMood()
        {
            if (message.Contains("sad"))
                return "SAD";
            else
                return "HAPPY";
        }



    }
}
