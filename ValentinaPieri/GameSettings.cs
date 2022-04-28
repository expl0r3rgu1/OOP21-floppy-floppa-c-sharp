using Utilities;
using InfiniteMap;
using LeaderboardSpace;
using System.Drawing;

namespace floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.ValentinaPieri
{
    /// <summary>
    /// GameSettings is the class that sets the Skin for the Character and the
    /// Background for ScrollingBackground
    /// </summary>
    public class GameSettings
    {
        private ScrollingBackground scollingBackground;
        private Skin skin;
        private Player player;
        private readonly Image image = null;
        private readonly int skin_dimension = 50;

        /// <summary>
        /// The Skin of the entity
        /// </summary>
        public Skin Skin { get => skin; set => skin = value; }

        /// <summary>
        /// The ScollingBackground of the entity
        /// </summary>
        public ScrollingBackground ScollingBackground { get => scollingBackground; set => scollingBackground = value; }

        /// <summary>
        /// The Player of the entity
        /// </summary>
        public Player Player { get => player; set => player = value; }

        public GameSettings()
        {
            this.scollingBackground = new ScrollingBackground("Default", image);
            this.skin = new Skin("Floppa", image, skin_dimension, skin_dimension);
        }

    }
}
