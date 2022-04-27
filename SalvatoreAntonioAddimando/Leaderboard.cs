using System.Collections;
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
            if (!File.Exists(leaderboardFilePath))
            {
                createLeaderboardFile();
            }

            leaderboard = new ArrayList<Player>();

            StreamReader leaderboardStreamReader = new StreamReader(leaderboardFilePath);

            skipToLeaderboardStart(leaderboardStreamReader);

            while ((line = leaderboardStreamReader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    leaderboard.add(new Player(line.Split(',')[0], int.Parse(line.Split(',')[1])));
                }
            }

            leaderboardStreamReader.Close();
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

        public void writeToFile()
        {
            StreamWriter leaderboardStreamWriter = File.AppendText(leaderboardFilePath);

            foreach (Player player in leaderboard)
            {
                leaderboardStreamWriter.WriteLine(player.ToString());
            }
        }

        private void binarySearchInsert(Player newPlayer)
        {
            int index = leaderboard.BinarySearch(newPlayer);

            if(index < 0) {
                index = ~index;
            }

            leaderboard.Insert(index, newPlayer);
        }
    }
}