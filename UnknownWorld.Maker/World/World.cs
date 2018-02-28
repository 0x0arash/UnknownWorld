using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownWorld.Maker.World
{
    public class World
    {
        private Random random;

        private int worldSeed;

        private List<Section> sections;

        public World(int seed)
        {
            worldSeed = seed;

            random = new Random(worldSeed);
        }

        public int GetRandomInt(int bound = -1)
        {
            return bound == -1 ? random.Next() : random.Next(bound);
        }

        public double GetRandomDouble()
        {
            return random.NextDouble();
        }
    }
}
