using System.IO;

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
    }

    private void createLeaderboardFile()
    {
        File.Create(leaderboardFilePath);
    }
}