using System.IO;

namespace LeaderboardSpace
{
    class Leaderboard
    {
        private const string leaderboardFilePath = "savings";
        private ArrayList<Player> leaderboard;

        public ArrayList<Player> Leaderboard
        {
            get { return leaderboard; }
        }

        public Leaderboard()
        {
            if(!File.Exists(leaderboardFilePath))
            {
                createLeaderboardFile();
            }

            leaderboard = new ArrayList<Player>();
        }

        private void createLeaderboardFile()
        {
            File.Create(leaderboardFilePath);
        }
    }
}