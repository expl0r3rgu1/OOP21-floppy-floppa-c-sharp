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
                CreateLeaderboardFile();
            }

            leaderboard = new ArrayList<Player>();

            StreamReader leaderboardStreamReader = new StreamReader(leaderboardFilePath);

            SkipToLeaderboardStart(leaderboardStreamReader);

            while ((line = leaderboardStreamReader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    leaderboard.add(new Player(line.Split(',')[0], int.Parse(line.Split(',')[1])));
                }
            }

            leaderboardStreamReader.Close();
        }

        private void SkipToLeaderboardStart(StreamReader streamReader)
        {
            for (int i = 0; i < 3; i++)
            {
                streamReader.ReadLine();
            }
        }

        private void CreateLeaderboardFile()
        {
            File.Create(leaderboardFilePath);
        }

        public void WriteToFile()
        {
            StreamWriter leaderboardStreamWriter = File.AppendText(leaderboardFilePath);

            foreach (Player player in leaderboard)
            {
                leaderboardStreamWriter.WriteLine(player.ToString());
            }
        }

        public void Update(Player newPlayer)
        {
            int playerIndexInLeaderboard = leaderboard.IndexOf(newPlayer);
            bool playerAlreadyPresent = (playerIndexInLeaderboard == -1) ? false : true;

            if (playerAlreadyPresent)
            {
                if (newPlayer.PersonalBest > leaderboard[playerIndexInLeaderboard].PersonalBest)
                {
                    leaderboard.RemoveAt(playerIndexInLeaderboard);

                    BinarySearchInsert(newPlayer);
                }
            }
            else
            {
                BinarySearchInsert(newPlayer);
            }
        }

        private void BinarySearchInsert(Player newPlayer)
        {
            int index = leaderboard.BinarySearch(newPlayer);

            if (index < 0)
            {
                index = ~index;
            }

            leaderboard.Insert(index, newPlayer);
        }

        public void ClearLeaderboard()
        {
            leaderboard.Clear();
        }
    }
}