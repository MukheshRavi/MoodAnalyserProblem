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
       
        [TestMethod]
        public void TestMoodAnalyserObject()
        {
            //Arrange
            object expected = new MoodAnalyser();
            //Act
            object actual = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyser"," MoodAnalyser");
            //Assert
            expected.Equals(actual);
        }


    }
}
