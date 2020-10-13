using System;

namespace MoodAnalyserProblem
{
   public class MoodAnalyser
    {
        public string message;
        //Refactor code to add constuctor
       
       public  MoodAnalyser()
        {
            Console.WriteLine("Default Constructor");
        }
          public  MoodAnalyser(string message)
        {
            this.message = message;
            Console.WriteLine("Paramterised constructor");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Problem");
            object noParameter = MoodAnalyserFactory.CreateMoodAnalyserObject(" MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");

            object withParameter = MoodAnalyserFactory.CreateMoodAnalyserParameterisedObject(" MoodAnalyserProblem.MoodAnalyser", 
                "MoodAnalyser","i am happy");


        }
        /// <summary>
        /// method to analyse mood
        /// </summary>
        /// <returns></returns>
        public string AnalyseMood()
        {
            try {
                if (message.ToLower().Contains("sad"))
                    return "SAD";
                else
                    if (message.Equals(" "))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be Empty");

                else if (message.Equals(null))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be Null");
                else
                    return "HAPPY";
            }
            catch(NullReferenceException )
            {
                return "Mood should not be Null" ;
            }
            catch (MoodAnalyserCustomException)
            {
                return "Mood should not be Empty";
            }

            
            }
           
            }
           
            
            }
  

