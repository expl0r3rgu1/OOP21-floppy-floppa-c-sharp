using System;

namespace LeaderboardSpace
{
    /// <summary>
    /// The user that is playing the game
    /// </summary>
    public class Player : IComparable
    {
        private readonly string nickname;
        private int personalBest;

        /// <summary>
        /// The nickname of the Player
        /// </summary>
        public string Nickname
        {
            get { return nickname; }
        }

        /// <summary>
        /// The best score of the Player
        /// </summary>
        public int PersonalBest
        {
            get { return personalBest; }
            set { personalBest = value; }
        }

        /// <param name="nickname">The nickname of the Player</param>
        /// <param name="personalBest">The best score of the Player</param>
        public Player(string nickname, int personalBest)
        {
            this.nickname = nickname;
            if (personalBest >= 0)
            {
                this.personalBest = personalBest;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return nickname + "," + personalBest;
        }

        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Player other = obj as Player;

            return other.PersonalBest - this.personalBest;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Player other = obj as Player;

            return this.nickname.Equals(other.Nickname);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
