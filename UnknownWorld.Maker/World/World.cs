using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnknownWorld.Core.Interfaces;

namespace UnknownWorld.Maker.World
{
    public class World : IUpdate, IInitialize, IDraw
    {
        private Random random;

        private int worldSeed;

        private int currentSection;
        private int sectionCount;

        public World(int seed, int sectionCount, int currentSection)
        {
            this.currentSection = currentSection;
            this.sectionCount = sectionCount;

            worldSeed = seed == -1 ? new Random(Int32.Parse(DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length / 2, DateTime.Now.Ticks.ToString().Length / 2 - 1))).Next() : seed;

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

        internal int GetSeed()
        {
            return worldSeed;
        }

        public void Update()
        {
            Section.GetSection(currentSection).Update();
        }

        public void Initialize()
        {
            Section.GenerateSections(this, 20, 20, sectionCount);
            Section.GetSection(currentSection).Update();
        }

        public void Draw()
        {
            Section.GetSection(currentSection).Update();
        }
    }
}
