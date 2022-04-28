using System.Collections.Generic;
using System.IO;

namespace LeaderboardSpace
{
    class Leaderboard
    {
        private const string leaderboardFilePath = "savings";
        private List<Player> leaderboardList;

        public List<Player> LeaderboardList
        {
            get { return leaderboardList; }
        }

        public Leaderboard()
        {
            if (!File.Exists(leaderboardFilePath))
            {
                CreateLeaderboardFile();
            }

            leaderboardList = new List<Player>();

            StreamReader leaderboardStreamReader = new StreamReader(leaderboardFilePath);

            SkipToLeaderboardStart(leaderboardStreamReader);
            string line = null;

            while ((line = leaderboardStreamReader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    leaderboardList.Add(new Player(line.Split(',')[0], int.Parse(line.Split(',')[1])));
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

            foreach (Player player in leaderboardList)
            {
                leaderboardStreamWriter.WriteLine(player.ToString());
            }
        }

        public void Update(Player newPlayer)
        {
            int playerIndexInLeaderboard = leaderboardList.IndexOf(newPlayer);
            bool playerAlreadyPresent = (playerIndexInLeaderboard == -1) ? false : true;

            if (playerAlreadyPresent)
            {
                if (newPlayer.PersonalBest > leaderboardList[playerIndexInLeaderboard].PersonalBest)
                {
                    leaderboardList.RemoveAt(playerIndexInLeaderboard);

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
            int index = leaderboardList.BinarySearch(newPlayer);

            if (index < 0)
            {
                index = ~index;
            }

            leaderboardList.Insert(index, newPlayer);
        }

        public void ClearLeaderboard()
        {
            leaderboardList.Clear();
        }
    }
}