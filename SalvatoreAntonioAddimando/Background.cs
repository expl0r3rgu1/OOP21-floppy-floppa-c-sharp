using Utilities.Movable;

namespace InfiniteMap
{
    class Background
    {
        private sealed string name;
        private sealed Image image;
        public string Name { get => name; set => name = value; }
        public Image Image { get => image; set => image = value; }
    }
}