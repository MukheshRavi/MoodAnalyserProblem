using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    class MoodAnalyserCustomException :Exception
    {
        public enum ExceptionType
        {
            EMPTY_MESSAGE,
            NULL_MESSAGE
        }
        public readonly ExceptionType type;

        public MoodAnalyserCustomException(ExceptionType type) : base()
        {
            this.type = type;
        }
    }


}
