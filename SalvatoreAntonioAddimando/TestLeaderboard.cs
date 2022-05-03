using System.IO;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class TestLeaderboard
    {
        private const string savingsFilePath = "savings";
        private const string savingsFileStartContent = "0\n0,0,0,0,0\n0,0,0,0,0";

        private void CreateSavingsFile()
        {
            File.Create(savingsFilePath);
            StreamWriter sw = new StreamWriter(savingsFilePath);
            sw.WriteLine(savingsFileStartContent);
            sw.Close();
        }
    }
}
