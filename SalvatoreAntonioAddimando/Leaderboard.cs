using System.Collections.Generic;
using System.IO;

namespace LeaderboardSpace
{
    /// <summary>
    /// The list of Player instances ordered by Player.PersonalBest
    /// </summary>
    class Leaderboard
    {
        private const string leaderboardFilePath = "savings";
        private List<Player> leaderboardList;

        /// <summary>
        /// The List of Player instances the played the game
        /// </summary>
        public List<Player> LeaderboardList
        {
            get { return leaderboardList; }
        }

        /// <summary>
        /// Initialized the Leaderboard by reading the savings file
        /// </summary>
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

        /// <summary>
        /// Saves the current Leaderboard List in the savings file
        /// </summary>
        public void WriteToFile()
        {
            StreamWriter leaderboardStreamWriter = File.AppendText(leaderboardFilePath);

            foreach (Player player in leaderboardList)
            {
                leaderboardStreamWriter.WriteLine(player.ToString());
            }
        }

        /// <summary>
        /// Updates the Leaderboard List with a new Player
        /// </summary>
        /// <param name="newPlayer">A new Player or an already existing Player with a different Player.personalBest(Score)</param>
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

        /// <summary>
        /// Clears the Leaderboard List
        /// </summary>
        public void ClearLeaderboard()
        {
            leaderboardList.Clear();
        }
    }
}