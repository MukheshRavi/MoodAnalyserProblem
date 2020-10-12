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
            [DataRow("Iam in sad mood")]
            [TestMethod]
            public void GiveSadAndGetSad(string message)
            {
                //Arrange
            MoodAnalyser    moodAnalyser = new MoodAnalyser();
                //Act
                var actual = moodAnalyser.AnalyseMood(message);
                //Assert
                Assert.AreEqual("SAD", actual);
            }

            /// <summary>
            /// doesnt give sad and get happy.
            /// </summary>
            /// <param name="message">The message.</param>
            [DataRow("Iam in happy mood")]
            [TestMethod]
            public void GiveHappyAndGetHappy(string message)
            {
                //Arrange
              MoodAnalyser  moodAnalyser = new MoodAnalyser();
                //Act
                var actual = moodAnalyser.AnalyseMood(message);
                //Assert
                Assert.AreEqual("HAPPY", actual);
            }
        }
}
