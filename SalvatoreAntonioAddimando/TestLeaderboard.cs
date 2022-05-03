using System.IO;
using NUnit.Framework;
using LeaderboardSpace;

namespace Test
{
    [TestFixture]
    public class TestLeaderboard
    {
        private const string savingsFilePath = "savings";
        private const string savingsFileStartContent = "0\n0,0,0,0,0\n0,0,0,0,0";

        [Test]
        public void TestLeaderboardInitialization()
        {
            CreateSavingsFile();

            Leaderboard leaderboard = new Leaderboard();

            Assert.IsNotNull(leaderboard.LeaderboardList);
            Assert.IsTrue(leaderboard.LeaderboardList.Count == 0);
        }

        private void CreateSavingsFile()
        {
            StreamWriter sw = new StreamWriter(File.Create(savingsFilePath));
            sw.WriteLine(savingsFileStartContent);
            sw.Close();
        }
    }
}
