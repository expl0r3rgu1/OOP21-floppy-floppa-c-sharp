namespace LeaderboardSpace
{
    public class Player
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

        public string ToString()
        {
            return nickname + "," + personalBest;
        }
    }
}
