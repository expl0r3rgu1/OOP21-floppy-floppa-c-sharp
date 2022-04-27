using System;

namespace LeaderboardSpace
{
    public class Player : IComparable
    {
        private sealed string nickname;
        private int personalBest;

        public string Nickname
        {
            get { return nickname; }
        }

        public int PersonalBest
        {
            get { return personalBest; }
            set { personalBest = value; }
        }

        public Player(string nickname, int personalBest)
        {
            this.nickname = nickname;
            if (personalBest >= 0)
            {
                this.personalBest = personalBest;
            }
        }

        public override string ToString()
        {
            return nickname + "," + personalBest;
        }

        public override int CompareTo(object obj)
        {
			if (obj == null) return 1;

			Player other = obj as Player;

			return other.PersonalBest - this.personalBest;
        }
    }
}
