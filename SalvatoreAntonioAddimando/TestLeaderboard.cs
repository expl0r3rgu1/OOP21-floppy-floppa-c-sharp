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

        [Test]
        public void TestLeaderboardAddPlayer()
        {
            CreateSavingsFile();

            Leaderboard leaderboard = new Leaderboard();

            Assert.IsNotNull(leaderboard.LeaderboardList);
            Assert.IsTrue(leaderboard.LeaderboardList.Count == 0);

            Player newPlayer = new Player("expl0r3rgu1", 50);
            leaderboard.Update(newPlayer);

            Assert.IsTrue(leaderboard.LeaderboardList.Count == 1);
            Assert.IsTrue(leaderboard.LeaderboardList.Contains(newPlayer));
        }

        private void CreateSavingsFile()
        {
            StreamWriter sw = new StreamWriter(File.Create(savingsFilePath));
            sw.WriteLine(savingsFileStartContent);
            sw.Close();
        }
    }
}
