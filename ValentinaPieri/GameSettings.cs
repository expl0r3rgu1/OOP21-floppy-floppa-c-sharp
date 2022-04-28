using Utilities;
using InfiniteMap;
using LeaderboardSpace;
using System.Drawing;

namespace floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.ValentinaPieri
{
    public class GameSettings
    {
        private ScrollingBackground scollingBackground;
        private Skin skin;
        private Player player;
        private readonly Image image = null;
        private readonly int skin_dimension = 50;

        public Skin Skin { get => skin; set => skin = value; }

        public ScrollingBackground ScollingBackground { get => scollingBackground; set => scollingBackground = value; }

        public Player Player { get => player; set => player = value; }

        public GameSettings()
        {
            this.scollingBackground = new ScrollingBackground("Default", image);
            this.skin = new Skin("Floppa", image, skin_dimension, skin_dimension);
        }

    }
}
