using System.IO;
using NUnit.Framework;
using LeaderboardSpace;

namespace Test
{
    [TestFixture]
    public class TestLeaderboard
    {
        private const string savingsFilePath = "savings";
        private const string savingsFileStartContent = "0\n1,0,0,0,0\n1,0,0,0,0";

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

        [Test]
        public void TestLeaderboardUpdatePlayer()
        {
            CreateSavingsFile();

            Leaderboard leaderboard = new Leaderboard();

            Assert.IsNotNull(leaderboard.LeaderboardList);
            Assert.IsTrue(leaderboard.LeaderboardList.Count == 0);

            string nickname = "expl0r3rgu1";

            Player player = new Player(nickname, 50);
            leaderboard.Update(player);

            Player updatedPlayer = new Player(nickname, 60);
            leaderboard.Update(updatedPlayer);

            Assert.IsTrue(leaderboard.LeaderboardList.Count == 1);
            Assert.IsNotNull(leaderboard.LeaderboardList.Contains(player));
            Assert.IsNotNull(leaderboard.LeaderboardList.Contains(updatedPlayer));
        }

        private void CreateSavingsFile()
        {
            StreamWriter sw = new StreamWriter(File.Create(savingsFilePath));
            sw.WriteLine(savingsFileStartContent);
            sw.Close();
        }
    }
}
