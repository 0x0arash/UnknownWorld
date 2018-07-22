using System;
using System.Collections.Generic;
using System.Linq;
using UnknownWorld.Core.Interfaces;

namespace UnknownWorld.Maker.World
{
    public class Section : IUpdate, IInitialize, IDraw
    {
        private static List<Section> sections;

        public static Section GetSection(int id)
        {
            return sections.First(o => o.id == id);
        }

        private World world;
        public World World
        {
            get { return world; }
        }

        public static int NextId = 1;

        private int id;

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

        private bool initialized = false;

        private List<Cell> cells;

        public Section(World wrd, int w, int h)
        {
            id = NextId;
            NextId++;

            world = wrd;

            width = w;
            height = h;
        }

        public Cell GenerateRandomCell()
        {
            Cell c = new Cell(this, world.GetRandomInt(7));
            return c;
        }

        public void Update()
        {
            //cells.ForEach(o => {
            //    if (o is IUpdate)
            //        ((IUpdate)o).Update();
            //});
        }

        internal static void GenerateSections(World wrd, int width, int height, int count)
        {
            sections = new List<Section>();

            for (int i = 0; i < count; i++)
            {
                sections.Add(new Section(wrd, width, height));
            }
        }

        public void Initialize()
        {
            //cells.ForEach(o => o.Initialize());
        }

        public void Draw()
        {
            if (!initialized)
                throw new Exception("This Section has not been initialized");


            //cells.ForEach(o => o.Draw());
        }
    }
}