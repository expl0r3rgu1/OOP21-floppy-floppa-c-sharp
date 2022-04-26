namespace LeaderboardSpace
{
	public class Player
	{
		private const string nickname;
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

		public Player(string nickname)
		{
			this.nickname = nickname;
		}
	}
}
