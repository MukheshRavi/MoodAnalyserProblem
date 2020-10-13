using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
namespace MoodTesting
{
    [TestClass]
    public class MoodTest
    {
     
            /// <summary>
            /// Tests the analyse mood method by giving sad and expecting sad
            /// </summary>
            [DataRow("I am in sad mood")]
            [TestMethod]
            public void GiveSadAndGetSad(string message)
            {
                //Arrange
            MoodAnalyser    moodAnalyser = new MoodAnalyser(message);
                //Act
                var actual = moodAnalyser.AnalyseMood();
                //Assert
                Assert.AreEqual("SAD", actual);
            }

            /// <summary>
            /// doesnt give sad and get happy.
            /// </summary>
            /// <param name="message">The message.</param>

            [DataRow("I am in Angry mood")]
            [TestMethod]
            public void GiveAngryAndGetHappy(string message)
            {
                //Arrange
              MoodAnalyser  moodAnalyser = new MoodAnalyser(message);
                //Act
                var actual = moodAnalyser.AnalyseMood();
                //Assert
                Assert.AreEqual("HAPPY", actual);
            }
        [DataRow(null)]
        [TestMethod]
        public void GiveNullAndGetHappy(string message)
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            var actual = moodAnalyser.AnalyseMood(); 
            //Assert
             Assert.AreEqual("Mood should not be Null", actual); 
        }
        [DataRow(" ")]
        [TestMethod]
        public void GiveEmptyAndGetHappy(string message)
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            var actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Mood should not be Empty", actual);
        }
       //created object for default constructor
        [TestMethod]
        public void TestMoodAnalyserObject()
        {
            //Arrange
            object expected = new MoodAnalyser();
            //Act
            object actual = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyser","MoodAnalyser");
            //Assert
            expected.Equals(actual);
        }
        //Created object for parameterised constructor
        [TestMethod]
        public void TestMoodAnalyserParameterisedObject()
        {
            //Arrange
            object expected = new MoodAnalyser("i am happy");
            //Act
            object actual = MoodAnalyserReflector.CreateMoodAnalyserParameterisedObject("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser","i am Happy");
            //Assert
            expected.Equals(actual);
        }
        /// <summary>
        /// Invoke mood Analyse method should return happy
        /// </summary>
        [TestMethod]
        public void TestInvokeMoodAnalyseMethod()
        {
            //Arrange
            string expected = new MoodAnalyser("i am happy").AnalyseMood();
            //Act
            string actual = MoodAnalyserReflector.InvokeAnalyseMoodMethod("i am happy","AnalyseMood");
            //Assert
            expected.Equals(actual);
        }
        /// <summary>
        /// Method name given wrong throws exception
        /// </summary>
        [TestMethod]
        public void TestInvokeInvalidMethod()
        {
            //Arrange
            string expected = new MoodAnalyser("i am happy").AnalyseMood();
            //Act
            string actual = MoodAnalyserReflector.InvokeAnalyseMoodMethod("i am happy", "InvalidMethod");
            //Assert
            expected.Equals(actual);
        }
        /// <summary>
        /// To get and set the field
        /// </summary>
        [TestMethod]
        public void TestGetFieldMethod()
        {
            //Arrange
            object expected = new MoodAnalyser("i am happy").AnalyseMood();
            //Act
            //first parameter-------Field Name , second parameter------New message
            object actual = MoodAnalyserReflector.GetFieldChangeMoodDynamically("message", "i am happy");
            //Assert
            expected.Equals(actual);
        }
        [TestMethod]
        public void TestGiveImproperFieldMethod()
        {
            //Arrange
            object expected = new MoodAnalyser("i am happy").AnalyseMood();
            //Act
            //first parameter-------Field Name , second parameter------New message
            object actual = MoodAnalyserReflector.GetFieldChangeMoodDynamically("ImproperField", "i am happy");
            //Assert
            expected.Equals(actual);
        }

    }
}
