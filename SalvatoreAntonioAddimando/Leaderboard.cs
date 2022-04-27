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

        private void skipToLeaderboardStart(StreamReader streamReader)
        {
            for (int i = 0; i < 3; i++)
            {
                streamReader.ReadLine();
            }
        }

        private void createLeaderboardFile()
        {
            File.Create(leaderboardFilePath);
        }
    }
}