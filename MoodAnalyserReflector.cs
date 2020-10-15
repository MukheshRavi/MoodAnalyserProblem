using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserReflector
    {
        public static object CreateMoodAnalyserObject(string className, string constructor)
        {//creating regex pattern to compare className and Constructor else it raises exception
            string pattern = @"." + constructor + "$";
            var result = Regex.Match(className, pattern);
            if (result.Success)
            {//If it matches it will create object else raises exception
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch (NullReferenceException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "constructor not found");
            }
        }
        public static object CreateMoodAnalyserParameterisedObject(string className, string constructor, string message)
        { // getting the type of class MoodAnalyser
            Type type = typeof(MoodAnalyser);
            // cheks if the class name exists in given assembly else throw exception
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                // checks if the constructor passed is correct then create object else throw Exception
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    Object obj = construct.Invoke(new object[] { message });
                    return obj;
                }
                else
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "constructor not found");
            }
            else
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
        }
        public static Object CreateMoodAnalyserDefaultMessageObject(string className, string constructor, string message = "Default")
        {
            // getting the type of class MoodAnalyser
            Type type = typeof(MoodAnalyser);

            // cheks if the class name exists in given assembly else throw exception
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                // checks if the constructor passed is correct then create object else throw Exception
                if (type.Name.Equals(constructor))
                {
                    if (message == "Default")
                        //Activate Default Constructor
                        return Activator.CreateInstance(type);
                    else
                        //Activate Parameterised Constructor
                        return Activator.CreateInstance(type, message);
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No such class found");
            }
        }


        public static string InvokeAnalyseMoodMethod(string message, string methodName)
        { // getting the type of class MoodAnalyser
            try
            {
                Type type = typeof(MoodAnalyser);
                // getting the method information  present in class MoodAnalyser else raises exception
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyser = MoodAnalyserReflector.CreateMoodAnalyserParameterisedObject("MoodAnalyserProblem.MoodAnalyser",
                    "MoodAnalyser", message);
                object method = methodInfo.Invoke(moodAnalyser, null);
                return method.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Method not found");
            }

        }

        public static string GetFieldChangeMoodDynamically(string fieldName, string message)
        {// getting the type of class MoodAnalyser
            try
            {
                Type type = typeof(MoodAnalyser);
                // getting the field information  present in class MoodAnalyser else raises exception
                FieldInfo fieldInfo = type.GetField(fieldName);
                fieldInfo.SetValue(new MoodAnalyser(), message);
                return InvokeAnalyseMoodMethod(message, "AnalyseMood");
              
            
            }
            
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
            catch
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be Null");
            }


        }
    }
}
