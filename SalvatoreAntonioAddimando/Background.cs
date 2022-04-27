using Utilities.Movable;

namespace InfiniteMap
{
    class Background : Movable
    {
        private sealed string name;
        private sealed Image image;
        public string Name { get => name; set => name = value; }
        public Image Image { get => image; set => image = value; }

        public Background(string name, Image image)
        {
            super(new Position(0, 0));
            this.name = name;
            this.image = image;
        }

        public Background(string name, Image image, Position position)
        {
            super(position);
            this.name = name;
            this.image = image;
        }
    }
}