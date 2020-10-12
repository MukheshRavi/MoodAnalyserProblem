using System;

namespace MoodAnalyserProblem
{
   public class MoodAnalyser
    {
        public string message;
        //Refactor code to add constuctor
        public MoodAnalyser(string message)
        {
            this.message = message;
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
            try {
                if (message.ToLower().Contains("sad"))
                    return "SAD";
                else
                    if (message.Equals(" "))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE);

                else if (message.Equals(null))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE);
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
  

