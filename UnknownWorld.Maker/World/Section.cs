using System.Collections.Generic;

namespace UnknownWorld.Maker.World
{
    public class Section
    {
        private World world;
        public World World
        {
            get { return world; }
        }

        private int width;
        private int height;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        private List<Cell> cells;

        public Section(World wrd, int w, int h)
        {
            world = wrd;
            width = w;
            height = h;
        }

        public Cell GenerateRandomCell()
        {
            Cell c = new Cell(this, world.GetRandomInt(7));
            return c;
        }
    }
}